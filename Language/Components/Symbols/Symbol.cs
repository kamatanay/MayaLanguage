
using System;

namespace Components
{	
	public class Symbol:AbstractSymbol
	{
		private object valueObject = null;
		
		public Symbol(string symbolName):base(symbolName)
		{
		}
		
		public Symbol(string symbolName, object valueObject):this(symbolName)
		{
			this.valueObject = valueObject;
		}		
		
		public Symbol Duplicate(){
			if (valueObject == null)
				return new Symbol(this.name);
			return new Symbol(this.name,valueObject);
		}
		
		public override bool Equals (object obj)
		{
			if (obj.GetType() != GetType())
				return false;
			Symbol objectSymbol = (Symbol)obj;
			if (!objectSymbol.name.Equals(name))
				return false;
			return true;
		}
		
		public override int GetHashCode ()
		{
			return this.name.GetHashCode();
		}
		
		public object Value(){
			return valueObject;
		}


	}
}
