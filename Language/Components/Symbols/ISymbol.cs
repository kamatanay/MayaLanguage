
using System;

namespace Components
{
	public interface ISymbol
	{
		bool IsTerminal();
		bool IsEndSymbol();
		object Value();
	}
}
