
using System;

namespace Components
{
	public interface IInput
	{
		ISymbol Get();
		void Next();
		ISymbol LastReadElement{get;set;}
		ISymbol PopFromStack();
		void PushToStack(ISymbol symbol);
	}
}
