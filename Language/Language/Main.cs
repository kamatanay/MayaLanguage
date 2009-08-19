using System;
using Components;

namespace Language
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Rule e1 = new Rule(new NonTerminal("E")).
				AddSymbol(new NonTerminal("E")).
				AddSymbol(new Operator("+")).
				AddSymbol(new NonTerminal("T"));
			
			Rule e2 = new Rule(new NonTerminal("E")).
				AddSymbol(new NonTerminal("T"));
			
			Rule e3 = new Rule(new NonTerminal("T")).
				AddSymbol(new NonTerminal("T")).
				AddSymbol(new Operator("*")).
				AddSymbol(new NonTerminal("F"));
			
			Rule e4 = new Rule(new NonTerminal("T")).
				AddSymbol(new NonTerminal("F"));
			
			Rule e5 = new Rule(new NonTerminal("F")).
				AddSymbol(new Literal());
			
			Rule e6 = new Rule(new NonTerminal("E")).
				AddSymbol(new Keyword("print")).
				AddSymbol(new NonTerminal("E"));
			
			Grammer grammer = new Grammer().
				AddRule(e1).
				AddRule(e2).
				AddRule(e3).
				AddRule(e4).
				AddRule(e5).
				AddRule(e6);
			
			States states = States.BuildStates(grammer);
			
			IInput input = new Input();
			Stack stack = new Stack();
			
			TreeNodeStack treeNodeStack = new TreeNodeStack();
			
			IAction action = states.GetAction(stack.Top(), input.Get());
			while(!action.GetType().Equals(typeof(Accept))){
				action.Do(input,stack,treeNodeStack);
				action = states.GetAction(stack.Top(),input.Get());
			}
			
			treeNodeStack.Pop().Execute();
		}
	}
}