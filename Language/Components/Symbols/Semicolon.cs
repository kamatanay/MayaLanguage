
using System;

namespace Components
{
	public class Semicolon:ISymbol
	{		
		public Semicolon()
		{
		}
		
		public ISymbol Duplicate(){
			return new Semicolon();
		}
		
		public override bool Equals (object obj)
		{
			Semicolon objectSymbol = obj as Semicolon;
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
			return ";";
		}						
	}
}
