
using System;

namespace Components
{
	public interface IAction
	{
		void Do(IInput input, Stack stack);
	}
}
