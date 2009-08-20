
using System;

namespace Components
{
	public class ParameterListTreeNode:ITreeNode
	{		
		private ITreeNode parameterListElements;
		
		public ParameterListTreeNode(ITreeNode parameterListElements)
		{
			this.parameterListElements = parameterListElements;
		}
		
		public ISymbol Execute(){
			if (parameterListElements == null)
				return null;
			return parameterListElements.Execute();
		}
	}
}
