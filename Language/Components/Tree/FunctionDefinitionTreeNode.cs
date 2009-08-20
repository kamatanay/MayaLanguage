
using System;

namespace Components
{
	public class FunctionDefinitionTreeNode:ITreeNode
	{
		private ITreeNode functionTreeNode;
		private int functionsIdentified;
		
		public FunctionDefinitionTreeNode(ITreeNode functionTreeNode, int functionsIdentified)
		{
			this.functionsIdentified = functionsIdentified;
			this.functionTreeNode = functionTreeNode;
		}
		
		public ISymbol Execute(){
			string functionLabel = "Function"+DateTime.Now.Ticks.ToString()+"_"+functionsIdentified;
			ContextProvider.GetContext().SetValueOf(functionLabel,functionTreeNode);
			return new FunctionIdentifier(functionLabel);
		}
	}
}
