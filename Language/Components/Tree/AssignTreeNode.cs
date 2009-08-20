
using System;
using System.Collections.Generic;

namespace Components
{
	public class AssignTreeNode:ITreeNode
	{		
		private ITreeNode valueTreeNode; 
		private ITreeNode identifierTreeNode;
		public AssignTreeNode(ITreeNode valueTreeNode, ITreeNode identifierTreeNode)
		{
			this.valueTreeNode = valueTreeNode;
			this.identifierTreeNode = identifierTreeNode;
		}
		
		public ISymbol Execute(){
			string variableName = identifierTreeNode.Execute().Value().ToString();
			ISymbol symbol = valueTreeNode.Execute();
			ContextProvider.GetContext().SetValueOf(variableName,symbol);
			return symbol;
		}
	}
}
