
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
			case 8: treeNodeStack.Push(new LiteralTreeNode(input.LastReadElement));break;
			case 6: treeNodeStack.Push(new MultiplyTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));
					break;
			case 4: treeNodeStack.Push(new AddTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));
					break;				
			case 9: treeNodeStack.Push(new PrintTreeNode(treeNodeStack.Pop()));
					break;
			case 2: treeNodeStack.Push(new ProgramTreeNode(treeNodeStack.Pop())); break;
			case 1: treeNodeStack.Push(new ProgramTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop())); break;
			case 10:treeNodeStack.Push(new IfTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
			}
		}
	}
}
