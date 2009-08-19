
using System;

namespace Components
{
	public class InitialNonTerminal:NonTerminal
	{
		public InitialNonTerminal(string symbol):base(symbol)
		{
		}
		
		public override string ToString ()
		{
			return base.ToString()+"_";
		}

	}
}
