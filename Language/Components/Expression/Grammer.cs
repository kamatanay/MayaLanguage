
using System;
using System.Collections.Generic;
using System.Collections;


namespace Components
{	
	public class Grammer
	{
		private ArrayList rules;
		private Dictionary<Symbol,bool> symbolsInGrammer;
		
		public Grammer()
		{
			rules = new ArrayList();
			symbolsInGrammer = new Dictionary<Symbol, bool>();
		}
		
		public Rule Get(int ruleId){
			return (Rule)rules[ruleId-1];
		}
		
		public void AddRule(Rule rule){
			rules.Add(rule);
			rule.RuleNumber = rules.Count;
			foreach(Symbol symbol in rule.Symbols()){
				if (!symbolsInGrammer.ContainsKey(symbol))
					symbolsInGrammer.Add(symbol,true);
			}
		}	
		
		public IEnumerable<Symbol> SymbolsInGrammer{
			get{
				foreach(Symbol symbol in symbolsInGrammer.Keys){
					yield return symbol;
				}
			}
		}
		
		public int GetGrammerRuleNumberFor(Rule rule){
			Rule duplicateRule = rule.Duplicate();
			duplicateRule.SetParsePosition(0);
			for (int ruleIndex=0;ruleIndex<rules.Count;ruleIndex++){
				Rule currentRule = (Rule)rules[ruleIndex];
				if (currentRule.ToString().Equals(duplicateRule.ToString()))
					return ruleIndex+1;
			}
			return -1;
		}
		
		public IEnumerable<Rule> GetRulesFor(Symbol symbol){
			foreach(Rule rule in this.rules){
				if (rule.GetSymbol().Equals(symbol))
					yield return rule.Duplicate();
			}
		}
		
		public Set GetInitialState(){
			Rule initialRule = new Rule(new Symbol(((Rule)rules[0]).GetSymbol().ToString()+"_"));
			initialRule.AddSymbol(new Symbol(((Rule)rules[0]).GetSymbol().ToString()));
			initialRule.AddSymbol(new Symbol("$"));
			Set initialSet = new Set(this);
			initialSet.AddRule(initialRule);
			foreach(Rule rule in rules){
				initialSet.AddRule(rule.Duplicate());
			}
			return initialSet;
		}
		
		public override string ToString(){
			string grammer = "";
			foreach(Rule rule in rules){
				grammer = grammer+rule.ToString();
			}
			return grammer;
		}
	}
}
