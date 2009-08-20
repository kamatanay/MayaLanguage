
using System;
using Components;

namespace Language
{
	public class GrammerBuilder
	{
		public Grammer GetGrammer()
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
			
			Rule e9 = new Rule(new NonTerminal("F")).
				AddSymbol(new NonTerminal("Variable"));
			
			Rule e10 = new Rule(new NonTerminal("Statement")).
				AddSymbol(new Keyword("if")).
				AddSymbol(new OpenBracket()).
				AddSymbol(new NonTerminal("E")).
				AddSymbol(new CloseBracket()).					
				AddSymbol(new NonTerminal("Program")).
				AddSymbol(new NonTerminal("IfOtherPart"));	
			
			Rule e11 = new Rule(new NonTerminal("IfOtherPart")).
				AddSymbol(new Keyword("end"));	
			
			Rule e12 = new Rule(new NonTerminal("IfOtherPart")).
				AddSymbol(new Keyword("else")).
				AddSymbol(new NonTerminal("Program")).
				AddSymbol(new Keyword("end"));	
			
			Rule e13 = new Rule(new NonTerminal("Statement")).
				AddSymbol(new Keyword("print")).
				AddSymbol(new NonTerminal("E")).			
				AddSymbol(new Semicolon());
			
			Rule e14 = new Rule(new NonTerminal("Variable")).
				AddSymbol(new Identifier(null));
			
			Rule e15 = new Rule(new NonTerminal("Statement")).
				AddSymbol(new NonTerminal("VariableDeclare")).
				AddSymbol(new NonTerminal("VariableInitialize"));

			Rule e16 = new Rule(new NonTerminal("VariableInitialize")).
				AddSymbol(new Semicolon());
			
			Rule e17 = new Rule(new NonTerminal("VariableInitialize")).
				AddSymbol(new Operator("=")).
				AddSymbol(new NonTerminal("E")).
				AddSymbol(new Semicolon());
				
			Rule e18 = new Rule(new NonTerminal("VariableDeclare")).
				AddSymbol(new Keyword("var")).
				AddSymbol(new Identifier(null));
			
			Rule e19 = new Rule(new NonTerminal("Statement")).
				AddSymbol(new NonTerminal("VariableAssign")).
				AddSymbol(new NonTerminal("E")).
				AddSymbol(new Semicolon());
			
			Rule e20 = new Rule(new NonTerminal("VariableAssign")).
				AddSymbol(new Identifier(null)).
				AddSymbol(new Operator("="));			
			
			Grammer grammer = new Grammer().
				AddRule(e1).
				AddRule(e2).
				AddRule(e3).
				AddRule(e4).
				AddRule(e5).
				AddRule(e6).
				AddRule(e7).
				AddRule(e8).
				AddRule(e9).
				AddRule(e10).
				AddRule(e11).
				AddRule(e12).
				AddRule(e13).
				AddRule(e14).
				AddRule(e15).
				AddRule(e16).
				AddRule(e17).
				AddRule(e18).
				AddRule(e19).
				AddRule(e20);
			
			return grammer;
		}		
	}
}
