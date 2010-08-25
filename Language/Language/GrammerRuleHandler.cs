
using System;
using Components;
using System.Collections.Generic;

namespace MayaLanguage
{
	public class GrammerRuleHandler:IGrammerRuleHandler
	{
		private IInput input;
		private TreeNodeStack treeNodeStack;
		private Dictionary<string,object> identifierMap;
		private Context context;
		private int functionsIdentified;
		
		public TreeNodeStack TreeNodeStack{
			set{
				this.treeNodeStack = value;		
			}
		}
		
		public GrammerRuleHandler(IInput input)
		{
			this.input = input;
			this.identifierMap = new Dictionary<string, object>();
			ContextProvider.GetContext().SetContexts(identifierMap);
			functionsIdentified = 0;
		}
		
		public void HandleRule(int ruleId){
			switch(ruleId){
				case 8: treeNodeStack.Push(new LiteralTreeNode(input.LastReadElement));break;
				case 6: treeNodeStack.Push(new MultiplyTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop(),treeNodeStack.Pop()));
						break;
				case 4: treeNodeStack.Push(new AddTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop(),treeNodeStack.Pop()));
						break;				
				case 13: treeNodeStack.Push(new PrintTreeNode(treeNodeStack.Pop()));
						break;
				case 2: treeNodeStack.Push(new ProgramTreeNode(treeNodeStack.Pop())); break;
				case 1: ITreeNode statementTreeNode = treeNodeStack.Pop();
						ProgramTreeNode programTreeNode = treeNodeStack.Pop() as ProgramTreeNode;
						programTreeNode.AddExpression(statementTreeNode);
						treeNodeStack.Push(programTreeNode); break;
				case 11:treeNodeStack.Push(new IfTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 12:treeNodeStack.Push(new IfTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 14: treeNodeStack.Push(new IdentifierTreeNode(input.LastReadElement));break;
				case 18: treeNodeStack.Push(new IdentifierTreeNode(input.LastReadElement));break;
				case 16: treeNodeStack.Push(new LiteralTreeNode(new Literal(null)));break;
				case 19: treeNodeStack.Push(new AssignTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 15: treeNodeStack.Push(new AssignTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 9: treeNodeStack.Push(new VariableTreeNode(treeNodeStack.Pop()));break;
				case 22: treeNodeStack.Push(new FunctionDefinitionTreeNode(treeNodeStack.Pop(),++functionsIdentified));break;
				case 23: treeNodeStack.Push(new FunctionCallTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 21: treeNodeStack.Push(new FunctionTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 26: treeNodeStack.Push(new ParameterListTreeNode(null));break;
				case 27: treeNodeStack.Push(new ParameterListElementsTreeNode(null,treeNodeStack.Pop()));break;
				case 28: treeNodeStack.Push(new ParameterListElementsTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 31: treeNodeStack.Push(new ParameterValueListTreeNode(null));break;
				case 32: treeNodeStack.Push(new ParameterValuesListElementsTreeNode(null,treeNodeStack.Pop()));break;
				case 33: treeNodeStack.Push(new ParameterValuesListElementsTreeNode(treeNodeStack.Pop(),treeNodeStack.Pop()));break;
				case 35: treeNodeStack.Push(new OperatorTreeNode(new Operator("+")));break;
				case 36: treeNodeStack.Push(new OperatorTreeNode(new Operator("-")));break;
				case 37: treeNodeStack.Push(new OperatorTreeNode(new Operator("*")));break;
				case 38: treeNodeStack.Push(new OperatorTreeNode(new Operator("/")));break;
			}
		}
		
	}
}
