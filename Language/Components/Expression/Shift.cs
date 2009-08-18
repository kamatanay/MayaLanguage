
using System;

namespace Components
{
	public class Shift:IAction
	{
		private int stateId;
		
		public Shift(int stateId)
		{
			this.stateId = stateId;
		}
		
		public void Do(IInput input, Stack stack){
			input.Next();
			stack.Push(stateId);
		}
	}
}
