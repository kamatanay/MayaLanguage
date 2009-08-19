using System;
using Components;

namespace Language
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Rule e1 = new Rule(new NonTerminal("E"));
			e1.AddSymbol(new NonTerminal("E"));
			e1.AddSymbol(new Operator("+"));
			e1.AddSymbol(new NonTerminal("T"));
			e1.AddSymbol(new End());
			
			Rule e2 = new Rule(new NonTerminal("E"));
			e2.AddSymbol(new NonTerminal("T"));
			e2.AddSymbol(new End());		
			
			Rule e3 = new Rule(new NonTerminal("T"));
			e3.AddSymbol(new NonTerminal("T"));
			e3.AddSymbol(new Operator("*"));
			e3.AddSymbol(new NonTerminal("F"));
			e3.AddSymbol(new End());		
			
			Rule e4 = new Rule(new NonTerminal("T"));
			e4.AddSymbol(new NonTerminal("F"));
			e4.AddSymbol(new End());				
			
			Rule e5 = new Rule(new NonTerminal("F"));
			e5.AddSymbol(new Literal());
			e5.AddSymbol(new End());		
			
			Rule e6 = new Rule(new NonTerminal("E"));
			e6.AddSymbol(new Keyword("print"));
			e6.AddSymbol(new NonTerminal("E"));
			e6.AddSymbol(new End());			
			
			Grammer grammer = new Grammer();
			grammer.AddRule(e1);
			grammer.AddRule(e2);
			grammer.AddRule(e3);
			grammer.AddRule(e4);
			grammer.AddRule(e5);
			grammer.AddRule(e6);
			
			States states = States.BuildStates(grammer);
			
			IInput input = new Input();
			Stack stack = new Stack();
			IAction action = states.GetAction(stack.Top(), input.Get());
			while(!action.GetType().Equals(typeof(Accept))){
				action.Do(input,stack);
				action = states.GetAction(stack.Top(),input.Get());
			}
		}
	}
}