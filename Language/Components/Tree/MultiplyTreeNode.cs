
using System;

namespace Components
{
	public class MultiplyTreeNode:ITreeNode
	{
		private ITreeNode leftTreeNode;
		private ITreeNode rightTreeNode;
		private ITreeNode operatorTreeNode;
		
		public MultiplyTreeNode(ITreeNode rightTreeNode, ITreeNode operatorTreeNode, ITreeNode leftTreeNode)
		{
			this.leftTreeNode = leftTreeNode;
			this.rightTreeNode = rightTreeNode;
			this.operatorTreeNode = operatorTreeNode;
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
			int result = 0;
			if (operatorTreeNode.Execute().ToString().Equals("*"))
				result = x*y;
			else
				result = x/y;			
			return new Literal(result);
		}		
	}
}
