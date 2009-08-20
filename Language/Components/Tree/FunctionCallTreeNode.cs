
using System;

namespace Components
{
	public class FunctionCallTreeNode:ITreeNode
	{
		private ITreeNode functionNameTreeNode;
		
		public FunctionCallTreeNode(ITreeNode functionNameTreeNode)
		{
			this.functionNameTreeNode = functionNameTreeNode;
		}
		
		public ISymbol Execute(){
			string functionName = functionNameTreeNode.Execute().Value().ToString();
			ITreeNode functionBody = ContextProvider.GetContext().GetValueOf(functionName) as ITreeNode;
			ContextProvider.GetContext().CreateNewContext();
			ISymbol returnValue = functionBody.Execute();
			ContextProvider.GetContext().DeleteRecentContext();
			return returnValue;
		}
	}
}
