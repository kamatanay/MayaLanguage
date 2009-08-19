
using System;

namespace Components
{
	public interface IInput
	{
		ISymbol Get();
		void Next();
		ISymbol LastReadElement{get;set;}
		void Parse();
	}
}
