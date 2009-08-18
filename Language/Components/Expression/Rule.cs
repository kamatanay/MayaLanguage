
using System;
using System.Collections;
using System.Collections.Generic;

namespace Components
{
	public class Rule
	{	
		private int ruleNumber;
		private Symbol symbol;
		private int parsePosition;
		private ArrayList ruleSymbols;
		
		public Rule(Symbol symbol)
		{
			this.symbol = symbol;
			this.parsePosition = 0;
			this.ruleSymbols = new ArrayList();
		}
		
		public int Length(){
			return ruleSymbols.Count - 1;
		}
		
		public Symbol GetSymbol(){
			return symbol;
		}
		
		public bool IsRuleFor(Symbol symbol){
			return this.symbol.Equals(symbol);
		}
		
		public int RuleNumber{
			get{
				return ruleNumber;
			}
			set{
				ruleNumber = value;
			}
		}
		
		public void AddSymbol(Symbol symbol){
			this.ruleSymbols.Add(symbol);
		}
		
		public Symbol GetCurrentParseSymbol(){
			return (Symbol)ruleSymbols[parsePosition];
		}
		
		public void SetParsePosition(int position){
			this.parsePosition = position;
		}
		
		public void NextParsePosition(){
			if (!IsRuleParsed())
				this.parsePosition++;
		}
		
		public bool IsRuleParsed(){
			return GetCurrentParseSymbol().IsEndSymbol();
		}
		
		public IEnumerable<Symbol> Symbols(){
			foreach(Symbol ruleSymbol in this.ruleSymbols){
				yield return ruleSymbol;
			}
		}
		
		public override string ToString(){
			string rule = "";
			rule = this.symbol.ToString()+ " -> ";
			for (int index=0;index < this.ruleSymbols.Count;index++){
				if (index == this.parsePosition)
					rule = rule + ".";
				rule = rule + this.ruleSymbols[index]+" ";
			}
			return rule;
		}
		
		public Rule Duplicate(){
			Rule duplicateRule = new Rule(this.symbol.Duplicate());
			foreach(Symbol ruleSymbol in ruleSymbols){
				duplicateRule.AddSymbol(ruleSymbol.Duplicate());
			}
			duplicateRule.SetParsePosition(this.parsePosition);
			duplicateRule.ruleNumber = ruleNumber;
			return duplicateRule;
		}
		
	}
}
