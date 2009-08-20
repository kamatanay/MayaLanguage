
using System;

namespace Components
{	
	public class IfTreeNode:ITreeNode
	{
		private ITreeNode conditionTreeNode;
		private ITreeNode trueStatementTreeNode;
		private ITreeNode falseStatementTreeNode;
		
		public IfTreeNode(ITreeNode falseStatementTreeNode, ITreeNode trueStatementTreeNode, ITreeNode conditionTreeNode)
		{
			this.conditionTreeNode = conditionTreeNode;
			this.trueStatementTreeNode = trueStatementTreeNode;
			this.falseStatementTreeNode = falseStatementTreeNode;
		}
		
		public IfTreeNode(ITreeNode trueStatementTreeNode, ITreeNode conditionTreeNode):this(null,trueStatementTreeNode,conditionTreeNode)
		{
		}		
		
		public ISymbol Execute(){
			ISymbol conditionSymbolOutput = conditionTreeNode.Execute();
			
			if (conditionSymbolOutput.GetType().Equals(typeof(Identifier)))
				conditionSymbolOutput = (ISymbol)ContextProvider.GetContext().GetValueOf(conditionSymbolOutput.Value().ToString());
			int conditionOutput = (int)conditionSymbolOutput.Value();
			if (conditionOutput>0)
				return trueStatementTreeNode.Execute();
			else if (falseStatementTreeNode != null)
				return falseStatementTreeNode.Execute();
			return conditionSymbolOutput;
		}
	}
}
