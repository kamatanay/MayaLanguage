
using System;

namespace Components
{
	public class Comma:ISymbol
	{		
		public Comma()
		{
		}
		
		public ISymbol Duplicate(){
			return new Comma();
		}
		
		public override bool Equals (object obj)
		{
			Comma objectSymbol = obj as Comma;
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
			return ",";
		}						
	}
}
