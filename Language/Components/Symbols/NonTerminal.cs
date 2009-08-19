
using System;

namespace Components
{
	public class NonTerminal:ISymbol
	{		
		private string symbol;
		
		public NonTerminal(string symbol)
		{
			this.symbol = symbol;
		}
		
		public ISymbol Duplicate(){
			return new NonTerminal(symbol);
		}
		
		public override bool Equals (object obj)
		{
			NonTerminal objectSymbol = obj as NonTerminal;
			return objectSymbol != null && objectSymbol.ToString().Equals(ToString());
		}
		
		public override int GetHashCode ()
		{
			return (this.GetType().ToString()+this.ToString()).GetHashCode();
		}
		
		public object Value(){
			return null;
		}	
		
		public bool IsEndSymbol(){
			return false;
		}
		
		public bool IsNonTerminal(){
			return true;
		}
		
		public override string ToString(){
			return symbol;
		}		
		
	}
}
