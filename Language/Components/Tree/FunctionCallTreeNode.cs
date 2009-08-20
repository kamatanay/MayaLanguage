
using System;

namespace Components
{
	public class FunctionCallTreeNode:ITreeNode
	{
		private ITreeNode functionNameTreeNode;
		private ITreeNode functionParameterValueTreeNode;
		
		public FunctionCallTreeNode(ITreeNode functionParameterValueTreeNode, ITreeNode functionNameTreeNode)
		{
			this.functionNameTreeNode = functionNameTreeNode;
			this.functionParameterValueTreeNode = functionParameterValueTreeNode;
		}
		
		public ISymbol Execute(){
			string functionName = functionNameTreeNode.Execute().Value().ToString();
			ITreeNode functionBody = ContextProvider.GetContext().GetValueOf(functionName) as ITreeNode;
			ContextProvider.GetContext().CreateNewContext();
			functionParameterValueTreeNode.Execute();
			ISymbol returnValue = functionBody.Execute();
			ContextProvider.GetContext().DeleteRecentContext();
			return returnValue;
		}
	}
}
