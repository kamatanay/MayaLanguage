
using System;
using System.Collections.Generic;

namespace Components
{
	public class VariableTreeNode:ITreeNode
	{		
		private ITreeNode identifierTreeNode;
		private Dictionary<string,object> identifierMap;
		
		public VariableTreeNode(ITreeNode identifierTreeNode, Dictionary<string,object> identifierMap)
		{
			this.identifierTreeNode = identifierTreeNode;
			this.identifierMap = identifierMap;
		}
		
		public ISymbol Execute(){
			ISymbol identifierSymbol = identifierTreeNode.Execute();
			ISymbol symbol = identifierMap[identifierSymbol.Value().ToString()] as ISymbol;
			return symbol;
		}	
	}
}
