
using System;
using System.Collections;

namespace Components
{
	public class TreeNodeStack
	{
		private System.Collections.Stack stack;
		
		public TreeNodeStack()
		{
			stack = new System.Collections.Stack();
		}
		
		public ITreeNode Top(){
			return (ITreeNode)stack.Peek();
		}
		
		public void Push(ITreeNode treeNode){
			stack.Push(treeNode);
		}
		
		public ITreeNode Pop(){
			return (ITreeNode)stack.Pop();
		}		
	}
}
