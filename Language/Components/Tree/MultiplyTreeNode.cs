
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
			int x = (int)leftTreeNode.Execute().Value();	
			int y = (int)rightTreeNode.Execute().Value();
			return new Literal(x*y);
		}		
	}
}
