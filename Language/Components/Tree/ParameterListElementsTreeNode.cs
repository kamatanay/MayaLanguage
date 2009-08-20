
using System;

namespace Components
{
	public class ParameterListElementsTreeNode:ITreeNode
	{
		private ITreeNode parameterListElements;
		private ITreeNode variableTreeNode;
		
		public ParameterListElementsTreeNode(ITreeNode parameterListElements,ITreeNode variableTreeNode)
		{
			this.parameterListElements = parameterListElements;
			this.variableTreeNode = variableTreeNode;
		}
		
		public ISymbol Execute(){
			if (parameterListElements != null)
				parameterListElements.Execute();
			if (variableTreeNode == null)
				return null;
			ISymbol symbolValue = variableTreeNode.Execute();
			if (symbolValue!=null)
				ContextProvider.GetContext().AddParameterName(variableTreeNode.Execute().Value().ToString());
			return null;
		}
	}
}
