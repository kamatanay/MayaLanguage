
using System;

namespace Components
{	
	public class IfTreeNode:ITreeNode
	{
		private ITreeNode conditionTreeNode;
		private ITreeNode statementTreeNode;
		
		public IfTreeNode(ITreeNode statementTreeNode, ITreeNode conditionTreeNode)
		{
			this.conditionTreeNode = conditionTreeNode;
			this.statementTreeNode = statementTreeNode;
		}
		
		public ISymbol Execute(){
			ISymbol conditionSymbolOutput = conditionTreeNode.Execute();
			int conditionOutput = (int)conditionSymbolOutput.Value();
			if (conditionOutput>0)
				return statementTreeNode.Execute();
			return conditionSymbolOutput;
		}
	}
}
