
using System;

namespace Components
{
	public class OpenBracket:ISymbol
	{
		public OpenBracket()
		{
		}
		
		public ISymbol Duplicate(){
			return new OpenBracket();
		}
		
		public override bool Equals (object obj)
		{
			OpenBracket objectSymbol = obj as OpenBracket;
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
			return "(";
		}		
	}
}
