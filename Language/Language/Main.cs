using System;
using Components;

namespace Language
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Rule e1 = new Rule(new Symbol("_E"));
			e1.AddSymbol(new Symbol("_E"));
			e1.AddSymbol(new Symbol("+"));
			e1.AddSymbol(new Symbol("_T"));
			e1.AddSymbol(new Symbol("$"));
			
			Rule e2 = new Rule(new Symbol("_E"));
			e2.AddSymbol(new Symbol("_T"));
			e2.AddSymbol(new Symbol("$"));		
			
			Rule e3 = new Rule(new Symbol("_T"));
			e3.AddSymbol(new Symbol("_T"));
			e3.AddSymbol(new Symbol("*"));
			e3.AddSymbol(new Symbol("_F"));
			e3.AddSymbol(new Symbol("$"));		
			
			Rule e4 = new Rule(new Symbol("_T"));
			e4.AddSymbol(new Symbol("_F"));
			e4.AddSymbol(new Symbol("$"));				
			
			Rule e5 = new Rule(new Symbol("_F"));
			e5.AddSymbol(new Symbol("id"));
			e5.AddSymbol(new Symbol("$"));		
			
			Rule e6 = new Rule(new Symbol("_E"));
			e6.AddSymbol(new Symbol("keyword","print"));
			e6.AddSymbol(new Symbol("_E"));
			e6.AddSymbol(new Symbol("$"));			
			
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