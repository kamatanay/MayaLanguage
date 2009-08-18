
using System;
using System.Collections;
using System.Collections.Generic;

namespace Components
{
	public class Set
	{
		private Grammer grammer;
		private ArrayList rules;
		private Dictionary<Symbol,bool> symbolsForGoto;
		private int reduceStateId;
		private bool isFinalState;
		
		public int ReduceStateId {
			get{return reduceStateId;}
			set{reduceStateId = value;}
		}
		
		public bool IsFinalState {			
			get{return isFinalState;}
			set{isFinalState = value;}
		}
		
		public Set(Grammer grammer)
		{
			this.grammer = grammer;
			this.rules = new ArrayList();
			this.symbolsForGoto = new Dictionary<Symbol, bool>();
			ReduceStateId = -1;
			IsFinalState = false;
		}
		
		public void AddRule(Rule rule){
			rules.Add(rule);
			if (rule.GetCurrentParseSymbol().IsEndSymbol())
				return;
			if (symbolsForGoto.ContainsKey(rule.GetCurrentParseSymbol()))
				symbolsForGoto[rule.GetCurrentParseSymbol()] = true;
			else
				symbolsForGoto.Add(rule.GetCurrentParseSymbol(),true);
		}	
		
		public IEnumerable<Symbol> GetSymbolsForGoto(){
			foreach(Symbol symbol in symbolsForGoto.Keys){
				yield return symbol;
			}
		}
		
		public Set Goto(Symbol symbol){
			Set newSet = new Set(this.grammer);
			foreach(Rule rule in this.rules){
				if (rule.GetCurrentParseSymbol().Equals(symbol)){
					Rule duplicateRule = rule.Duplicate();
					duplicateRule.NextParsePosition();
					newSet.AddRule(duplicateRule);
					if (duplicateRule.IsRuleParsed()){
						if (duplicateRule.RuleNumber == 0){
							newSet.IsFinalState = true;
						}
						newSet.ReduceStateId = this.grammer.GetGrammerRuleNumberFor(duplicateRule);
					}
				}
			}
			while(true){
				ArrayList ruleList = new ArrayList();
				foreach(Rule rule in newSet.rules){
					Symbol currentParseSymbol = rule.GetCurrentParseSymbol();
					foreach(Rule closingRule in this.grammer.GetRulesFor(currentParseSymbol)){
						if (!newSet.ToString().Contains(closingRule.ToString()))
							ruleList.Add(closingRule);
					}
				}
				foreach(Object ruleObject in ruleList)
					newSet.AddRule((Rule)ruleObject);
				if (ruleList.Count==0)
					break;
			}
			return newSet;
		}
		
		public override string ToString(){
			string setRules = "";
			foreach(Rule rule in rules){
				setRules = setRules+rule.ToString();
			}
			return setRules;
		}		
	}
}
