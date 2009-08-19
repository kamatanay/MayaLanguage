
using System;
using System.Collections;
using Components;

namespace Language
{
	public class Input:IInput
	{
		private ArrayList inputs;
		private int position;
		private System.Collections.Stack stack;
		private ISymbol lastReadElement;
		
		public ISymbol LastReadElement{
			get{return lastReadElement;}
			set{lastReadElement = value;}
		}
		
		public Input()
		{
			inputs = new ArrayList();
			inputs.Add(new Keyword("print"));
			inputs.Add(new Literal(5));
			inputs.Add(new Operator("+"));
			inputs.Add(new Literal(4));
			inputs.Add(new Operator("*"));
			inputs.Add(new Literal(2));			
			inputs.Add(new End());
			position = 0;
			stack = new System.Collections.Stack();
		}
		
		public ISymbol Get(){
			if (((ISymbol)inputs[position]).Value() != null)
				LastReadElement = (ISymbol)inputs[position];
			return (ISymbol)inputs[position];
		}
		
		public void Next(){
			position++;
		}
		
		public ISymbol PopFromStack(){
			return (ISymbol)stack.Pop();
		}
		
		public void PushToStack(ISymbol symbol){
			stack.Push(symbol);
		}
	}
}
