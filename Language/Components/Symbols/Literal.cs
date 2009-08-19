
using System;

namespace Components
{
	public class Literal:ISymbol
	{		
		private object symbolValue;
		
		public Literal(object symbolValue)
		{
			this.symbolValue = symbolValue;
		}
		
		public Literal():this(null)
		{
		}		
		
		public ISymbol Duplicate(){
			return new Literal(symbolValue);
		}
		
		public override bool Equals (object obj)
		{
			Literal objectSymbol = obj as Literal;
			return objectSymbol != null;
		}
		
		public override int GetHashCode ()
		{
			return this.GetType().ToString().GetHashCode();
		}
		
		public object Value(){
			return symbolValue;
		}	
		
		public bool IsEndSymbol(){
			return false;
		}
		
		public bool IsNonTerminal(){
			return false;
		}
		
		public override string ToString(){
			return "literal";
		}		
	}
}
