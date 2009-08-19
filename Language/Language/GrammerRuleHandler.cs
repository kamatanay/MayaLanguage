
using System;
using Components;

namespace Language
{
	public class GrammerRuleHandler:IGrammerRuleHandler
	{
		private IInput input;
		private TreeNodeStack treeNodeStack;
		
		public TreeNodeStack TreeNodeStack{
			set{
				this.treeNodeStack = value;		
			}
		}
		
		public GrammerRuleHandler(IInput input)
		{
			this.input = input;
		}
		
		public void HandleRule(int ruleId){
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
