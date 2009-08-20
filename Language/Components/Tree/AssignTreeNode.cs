
using System;
using System.Collections.Generic;

namespace Components
{
	public class AssignTreeNode:ITreeNode
	{		
		private ITreeNode valueTreeNode; 
		private IdentifierTreeNode identifierTreeNode;
		private Dictionary<string,object> identifierMap;
		public AssignTreeNode(ITreeNode valueTreeNode, ITreeNode identifierTreeNode, Dictionary<string,object> identifierMap)
		{
			this.valueTreeNode = valueTreeNode;
			this.identifierTreeNode = identifierTreeNode as IdentifierTreeNode;
			this.identifierMap = identifierMap;
		}
		
		public ISymbol Execute(){
			string variableName = identifierTreeNode.Execute().Value().ToString();
			identifierMap[variableName] = valueTreeNode.Execute();
			return identifierMap[variableName] as ISymbol;
		}
	}
}
