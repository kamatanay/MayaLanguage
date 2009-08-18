
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
		private Symbol lastReadElement;
		
		public Symbol LastReadElement{
			get{return lastReadElement;}
			set{lastReadElement = value;}
		}
		
		public Input()
		{
			inputs = new ArrayList();
			inputs.Add(new Symbol("keyword","print"));
			inputs.Add(new Symbol("id",5));
			inputs.Add(new Symbol("*"));
			inputs.Add(new Symbol("id",4));
			inputs.Add(new Symbol("+"));
			inputs.Add(new Symbol("id",2));			
			inputs.Add(new Symbol("$"));
			position = 0;
			stack = new System.Collections.Stack();
		}
		
		public Symbol Get(){
			if (((Symbol)inputs[position]).Value() != null)
				LastReadElement = (Symbol)inputs[position];
			return (Symbol)inputs[position];
		}
		
		public void Next(){
			position++;
		}
		
		public Symbol PopFromStack(){
			return (Symbol)stack.Pop();
		}
		
		public void PushToStack(Symbol symbol){
			stack.Push(symbol);
		}
	}
}
