
using System;
using Components;

namespace Components
{
	public class Parser
	{
		
		public ITreeNode Parse(Grammer grammer, IInput input, IGrammerRuleHandler ruleHandler){
			
			States states = States.BuildStates(grammer);
		
			input.Parse();

			Stack stack = new Stack();
			
			TreeNodeStack treeNodeStack = new TreeNodeStack();
			
			ruleHandler.TreeNodeStack = treeNodeStack;
			
			IAction action = states.GetAction(stack.Top(), input.Get());
			while(!action.GetType().Equals(typeof(Accept))){
				action.Do(input,stack,ruleHandler);
				action = states.GetAction(stack.Top(),input.Get());
			}
			
			return treeNodeStack.Pop();
		}
		
	}
}
