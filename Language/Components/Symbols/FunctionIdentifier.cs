
using System;

namespace Components
{
	public class FunctionIdentifier:ISymbol
	{		
		private string functionIdentifier;
		
		public FunctionIdentifier(string functionIdentifier)
		{
			this.functionIdentifier = functionIdentifier;
		}
		
		public ISymbol Duplicate(){
			return new FunctionIdentifier(functionIdentifier);
		}
		
		public override bool Equals (object obj)
		{
			FunctionIdentifier objectSymbol = obj as FunctionIdentifier;
			return objectSymbol != null && objectSymbol.ToString().Equals(ToString());
		}
		
		public override int GetHashCode ()
		{
			return (this.GetType().ToString()+this.ToString()).GetHashCode();
		}
		
		public object Value(){
			return functionIdentifier;
		}	
		
		public bool IsEndSymbol(){
			return false;
		}
		
		public bool IsNonTerminal(){
			return false;
		}
		
		public override string ToString(){
			return "functionIdentifier";
		}		
	}
}
