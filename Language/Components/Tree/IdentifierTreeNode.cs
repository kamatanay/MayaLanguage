
using System;
using System.Collections.Generic;

namespace Components
{
	public class IdentifierTreeNode:ITreeNode
	{		
		private ISymbol identifierName;
		
		public IdentifierTreeNode(ISymbol identifierName)
		{
			this.identifierName = identifierName;
		}
		
		public ISymbol Execute(){
			return identifierName;
		}		
	}
}
