
using System;

namespace Components
{
	public class Operator:ISymbol
	{
		private string operatorSymbol;
		
		public Operator(string operatorSymbol)
		{
			this.operatorSymbol = operatorSymbol;
		}
		
		public ISymbol Duplicate(){
			return new Operator(operatorSymbol);
		}
		
		public override bool Equals (object obj)
		{
			Operator objectSymbol = obj as Operator;
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
			return false;
		}
		
		public override string ToString(){
			return operatorSymbol;
		}				
	}
}
