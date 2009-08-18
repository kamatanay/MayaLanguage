
using System;

namespace Components
{
	public interface IInput
	{
		Symbol Get();
		void Next();
		Symbol LastReadElement{get;set;}
		Symbol PopFromStack();
		void PushToStack(Symbol symbol);
	}
}
