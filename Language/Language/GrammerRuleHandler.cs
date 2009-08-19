
using System;
using Components;
using System.Collections.Generic;

namespace Language
{
	public class GrammerRuleHandler:IGrammerRuleHandler
	{
		private IInput input;
		private TreeNodeStack treeNodeStack;
		private Dictionary<string,object> identifierMap;
		
		public TreeNodeStack TreeNodeStack{
			set{
				this.treeNodeStack = value;		
			}
		}
		
		public GrammerRuleHandler(IInput input)
		{
			this.input = input;
			this.identifierMap = new Dictionary<string, object>();
		}
		
		public void HandleRule(int ruleId){
			switch(ruleId){
				case 8: treeNodeStack.Push(new LiteralTreeNode(input.LastReadElement));break;
				case 6: treeNodeStack.Push(new MultiplyTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));
						break;
				case 4: treeNodeStack.Push(new AddTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));
						break;				
				case 13: treeNodeStack.Push(new PrintTreeNode(treeNodeStack.Pop()));
						break;
				case 2: treeNodeStack.Push(new ProgramTreeNode(treeNodeStack.Pop())); break;
				case 1: treeNodeStack.Push(new ProgramTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop())); break;
				case 11:treeNodeStack.Push(new IfTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 12:treeNodeStack.Push(new IfTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 14: treeNodeStack.Push(new IdentifierTreeNode(input.LastReadElement,identifierMap));break;
				case 16: treeNodeStack.Push(new LiteralTreeNode(new Literal(null)));break;
				case 15: treeNodeStack.Push(new AssignTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop(),identifierMap));break;
			}
		}
		
	}
}
