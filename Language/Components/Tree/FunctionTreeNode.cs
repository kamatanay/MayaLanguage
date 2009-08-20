
using System;

namespace Components
{
	public class FunctionTreeNode:ITreeNode
	{		
		private ITreeNode functionBody;
		private ITreeNode parameterList;
		
		public FunctionTreeNode(ITreeNode functionBody, ITreeNode parameterList)
		{
			this.functionBody = functionBody;
			this.parameterList = parameterList;
		}
		
		public ISymbol Execute(){
			parameterList.Execute();
			ContextProvider.GetContext().CopyToVariableTable();
			return functionBody.Execute();
		}
	}
}
