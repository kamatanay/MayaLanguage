
using System;

namespace Components
{
	public class LiteralTreeNode:ITreeNode
	{		
		private Literal literal;
		
		public LiteralTreeNode(ISymbol literal)
		{
			this.literal = literal as Literal;
		}
		
		public ISymbol Execute(){
			return this.literal;
		}
		
	}
}
