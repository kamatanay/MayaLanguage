
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
			ISymbol valueSymbol = identifierTreeNode.Execute();
			string variableName = valueSymbol.Value().ToString();
			ISymbol symbol = valueTreeNode.Execute();
			
			if (symbol.GetType().Equals(typeof(FunctionIdentifier))){
				string functionLabel = symbol.Value().ToString();
				ITreeNode functionTreeNode = ContextProvider.GetContext().GetValueOf(functionLabel) as ITreeNode;
				ContextProvider.GetContext().SetValueOf(variableName,functionTreeNode);
				return symbol;
			}
			ContextProvider.GetContext().SetValueOf(variableName,symbol);
			return symbol;
		}
	}
}
