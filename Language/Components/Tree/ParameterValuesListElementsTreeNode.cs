
using System;

namespace Components
{
	public class ParameterValuesListElementsTreeNode:ITreeNode
	{
		private ITreeNode parameterValueListElements;
		private ITreeNode valueTreeNode;
		
		public ParameterValuesListElementsTreeNode(ITreeNode parameterValueListElements,ITreeNode valueTreeNode)
		{
			this.parameterValueListElements = parameterValueListElements;
			this.valueTreeNode = valueTreeNode;
		}
		
		public ISymbol Execute(){
			if (parameterValueListElements != null)
				parameterValueListElements.Execute();
			if (valueTreeNode == null)
				return null;
			ISymbol symbolValue = valueTreeNode.Execute();
			if (symbolValue!=null)
				AddParameterValue(symbolValue);
			return null;
		}		
		
		private void AddParameterValue(ISymbol symbolValue){
			object setValue = symbolValue;
			if (symbolValue.GetType().Equals(typeof(Identifier)))
				setValue = ContextProvider.GetContext().GetValueOf(symbolValue.Value().ToString());
			ContextProvider.GetContext().AddParameterValue(setValue);
		}
	}
}
