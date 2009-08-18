
using System;
using System.Collections;

namespace Components
{
	public class Stack
	{
		private System.Collections.Stack stack;
		
		public Stack()
		{
			stack = new System.Collections.Stack();
			stack.Push(0);
		}
		
		public int Top(){
			return (int)stack.Peek();
		}
		
		public void Push(int stateId){
			stack.Push(stateId);
		}
		
		public void Pop(){
			stack.Pop();
		}		
	}
}
