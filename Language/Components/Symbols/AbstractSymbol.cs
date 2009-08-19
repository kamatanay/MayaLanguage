
using System;

namespace Components
{
	public class AbstractSymbol
	{
		protected string name;
		private object symbolValue;
		
		public AbstractSymbol(string name)
		{
			this.name = name;
		}
		
		protected AbstractSymbol(){
		}
		
		public bool IsEndSymbol(){
			return this.name.Equals("$");
		}
		
		public bool IsNonTerminal(){
			return this.name.StartsWith("_");
		}
		
		public override string ToString(){
			return this.name;
		}
	}
}
