
using System;

namespace Components
{
	public class CloseBracket:ISymbol
	{		
		public CloseBracket()
		{
		}
		
		public ISymbol Duplicate(){
			return new CloseBracket();
		}
		
		public override bool Equals (object obj)
		{
			CloseBracket objectSymbol = obj as CloseBracket;
			return objectSymbol != null;
		}
		
		public override int GetHashCode ()
		{
			return this.GetType().ToString().GetHashCode();
		}
		
		public object Value(){
			return null;
		}	
		
		public bool IsEndSymbol(){
			return false;
		}
		
		public bool IsNonTerminal(){
			return false;
		}
		
		public override string ToString(){
			return ")";
		}				
	}
}
