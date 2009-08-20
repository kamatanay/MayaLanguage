
using System;

namespace Components
{

	public class ParameterValueListTreeNode:ITreeNode
	{
		private ITreeNode parameterValueListElements;
		
		public ParameterValueListTreeNode(ITreeNode parameterValueListElements)
		{
			this.parameterValueListElements = parameterValueListElements;
		}
		
		public ISymbol Execute(){
			if (parameterValueListElements == null)
				return null;
			return parameterValueListElements.Execute();
		}		
		
	}
}
