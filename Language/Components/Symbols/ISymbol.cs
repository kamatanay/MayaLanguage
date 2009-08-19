
using System;

namespace Components
{
	public interface ISymbol
	{
		bool IsNonTerminal();
		bool IsEndSymbol();
		object Value();
		ISymbol Duplicate();
	}
}
