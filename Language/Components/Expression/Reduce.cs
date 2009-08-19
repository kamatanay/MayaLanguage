
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
		
		public void Do(IInput input, Stack stack, TreeNodeStack treeNodeStack){
			Rule rule = grammer.Get(ruleId);
			int ruleLength = rule.Length();
			for (int index=0; index<ruleLength;index++){
				stack.Pop();
			}
			int stateId = stack.Top();
			IAction action = states.GetAction(stateId,rule.GetSymbol());
			action.Do(input,stack,treeNodeStack);
			
			switch(ruleId){
			case 5: treeNodeStack.Push(new LiteralTreeNode(input.LastReadElement));break;
			case 3: treeNodeStack.Push(new MultiplyTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));
					break;
			case 1: treeNodeStack.Push(new AddTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));
					break;				
			case 6: treeNodeStack.Push(new PrintTreeNode(treeNodeStack.Pop()));
					break;
			}
		}
	}
}
