
using System;

namespace Components
{
	public class AddTreeNode:ITreeNode
	{
		private ITreeNode leftTreeNode;
		private ITreeNode rightTreeNode;
		
		public AddTreeNode(ITreeNode leftTreeNode, ITreeNode rightTreeNode)
		{
			this.leftTreeNode = leftTreeNode;
			this.rightTreeNode = rightTreeNode;
		}
		
		public ISymbol Execute(){
			int x = (int)leftTreeNode.Execute().Value();	
			int y = (int)rightTreeNode.Execute().Value();
			return new Literal(x+y);
		}
	}
}
