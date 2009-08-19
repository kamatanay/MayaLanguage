
using System;

namespace Components
{
	public class End:ISymbol
	{		
		public End()
		{
		}
		
		public ISymbol Duplicate(){
			return new End();
		}
		
		public override bool Equals (object obj)
		{
			End objectSymbol = obj as End;
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
			return true;
		}
		
		public bool IsNonTerminal(){
			return false;
		}
		
		public override string ToString(){
			return "$";
		}				
	}
}
