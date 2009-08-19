
using System;

namespace Components
{
	public class Identifier:ISymbol
	{		
		private string identifier;
		
		public Identifier(string identifier)
		{
			this.identifier = identifier;
		}
		
		public ISymbol Duplicate(){
			return new Identifier(identifier);
		}
		
		public override bool Equals (object obj)
		{
			Identifier objectSymbol = obj as Identifier;
			return objectSymbol != null && objectSymbol.ToString().Equals(ToString());
		}
		
		public override int GetHashCode ()
		{
			return (this.GetType().ToString()+this.ToString()).GetHashCode();
		}
		
		public object Value(){
			return identifier;
		}	
		
		public bool IsEndSymbol(){
			return false;
		}
		
		public bool IsNonTerminal(){
			return false;
		}
		
		public override string ToString(){
			return "identifier";
		}				
	}
}
