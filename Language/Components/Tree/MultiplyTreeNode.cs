
using System;

namespace Components
{
	public class MultiplyTreeNode:ITreeNode
	{
		private ITreeNode leftTreeNode;
		private ITreeNode rightTreeNode;
		
		public MultiplyTreeNode(ITreeNode leftTreeNode, ITreeNode rightTreeNode)
		{
			this.leftTreeNode = leftTreeNode;
			this.rightTreeNode = rightTreeNode;
		}
		
		public ISymbol Execute(){
			ISymbol xSymbol = leftTreeNode.Execute();
			ISymbol ySymbol = rightTreeNode.Execute();
			if (xSymbol.GetType().Equals(typeof(Identifier)))
			    xSymbol = (ISymbol)ContextProvider.GetContext().GetValueOf(xSymbol.Value().ToString());
			if (ySymbol.GetType().Equals(typeof(Identifier)))
			    ySymbol = (ISymbol)ContextProvider.GetContext().GetValueOf(ySymbol.Value().ToString());			
			int x = (int)xSymbol.Value();	
			int y = (int)ySymbol.Value();
			return new Literal(x*y);
		}		
	}
}
