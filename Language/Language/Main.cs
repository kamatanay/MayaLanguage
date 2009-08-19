using System;
using Components;

namespace Language
{
	class MainClass
	{
		public static void Main(string[] args)
		{
		
			Rule e1 = new Rule(new NonTerminal("Program")).
				AddSymbol(new NonTerminal("Program")).
				AddSymbol(new NonTerminal("Statement"));
			
			Rule e2 = new Rule(new NonTerminal("Program")).
				AddSymbol(new NonTerminal("Statement"));
			
			Rule e3 = new Rule(new NonTerminal("Statement")).
				AddSymbol(new NonTerminal("E")).
				AddSymbol(new Semicolon());
				
			Rule e4 = new Rule(new NonTerminal("E")).
				AddSymbol(new NonTerminal("E")).
				AddSymbol(new Operator("+")).
				AddSymbol(new NonTerminal("T"));
			
			Rule e5 = new Rule(new NonTerminal("E")).
				AddSymbol(new NonTerminal("T"));
			
			Rule e6 = new Rule(new NonTerminal("T")).
				AddSymbol(new NonTerminal("T")).
				AddSymbol(new Operator("*")).
				AddSymbol(new NonTerminal("F"));
			
			Rule e7 = new Rule(new NonTerminal("T")).
				AddSymbol(new NonTerminal("F"));
			
			Rule e8 = new Rule(new NonTerminal("F")).
				AddSymbol(new Literal());
			
			Rule e9 = new Rule(new NonTerminal("E")).
				AddSymbol(new Keyword("print")).
				AddSymbol(new NonTerminal("E"));
			
			Grammer grammer = new Grammer().
				AddRule(e1).
				AddRule(e2).
				AddRule(e3).
				AddRule(e4).
				AddRule(e5).
				AddRule(e6).
				AddRule(e7).
				AddRule(e8).
				AddRule(e9);
			
			States states = States.BuildStates(grammer);
			
			IInput input = new Input();
			input.Parse();
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