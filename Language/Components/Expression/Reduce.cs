
using System;

namespace Components
{
	public class Reduce:IAction
	{
		private int ruleId;
		private Grammer grammer;
		private States states;
		
		public Reduce(int ruleId, Grammer grammer, States states)
		{
			this.ruleId = ruleId;
			this.grammer = grammer;
			this.states = states;
		}
		
		public void Do(IInput input, Stack stack){
			Rule rule = grammer.Get(ruleId);
			int ruleLength = rule.Length();
			for (int index=0; index<ruleLength;index++){
				stack.Pop();
			}
			int stateId = stack.Top();
			IAction action = states.GetAction(stateId,rule.GetSymbol());
			action.Do(input,stack);
			
			switch(ruleId){
			case 5: input.PushToStack(input.LastReadElement);break;
			case 3: input.PushToStack(new Literal((int)input.PopFromStack().Value()*(int)input.PopFromStack().Value()));
					break;
			case 1: input.PushToStack(new Literal((int)input.PopFromStack().Value()+(int)input.PopFromStack().Value()));
					break;				
			case 6: PrintOperation(input,input.PopFromStack());
					break;
			}
		}
		
		private void PrintOperation(IInput input, ISymbol symbol){
			Console.WriteLine(symbol.Value().ToString());
			input.PushToStack(symbol);
		}
	}
}
