
using System;
using System.Collections.Generic;

namespace Components
{
	public class VariableTreeNode:ITreeNode
	{		
		private ITreeNode identifierTreeNode;
		
		public VariableTreeNode(ITreeNode identifierTreeNode)
		{
			this.identifierTreeNode = identifierTreeNode;
		}
		
		public ISymbol Execute(){
			return identifierTreeNode.Execute();
		}	
	}
}
