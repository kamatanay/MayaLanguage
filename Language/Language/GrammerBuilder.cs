
using System;
using Components;

namespace MayaLanguage
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
				AddSymbol(new NonTerminal("AddSubtractOperator")).
				AddSymbol(new NonTerminal("T"));
			
			Rule e5 = new Rule(new NonTerminal("E")).
				AddSymbol(new NonTerminal("T"));
			
			Rule e6 = new Rule(new NonTerminal("T")).
				AddSymbol(new NonTerminal("T")).
				AddSymbol(new NonTerminal("MultiplyDivisionOperator")).
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
				AddSymbol(new NonTerminal("VariableValue"));
				
			Rule e18 = new Rule(new NonTerminal("VariableDeclare")).
				AddSymbol(new Keyword("var")).
				AddSymbol(new Identifier(null));
			
			Rule e19 = new Rule(new NonTerminal("Statement")).
				AddSymbol(new NonTerminal("Variable")).
				AddSymbol(new Operator("=")).
				AddSymbol(new NonTerminal("VariableValue"));
			
			Rule e20 = new Rule(new NonTerminal("VariableValue")).
				AddSymbol(new NonTerminal("E")).
				AddSymbol(new Semicolon());	
			
			Rule e21 = new Rule(new NonTerminal("FunctionDefinition")).
				AddSymbol(new Keyword("function")).
				AddSymbol(new OpenBracket()).
				AddSymbol(new NonTerminal("ParameterList")).
				AddSymbol(new NonTerminal("Program")).
				AddSymbol(new Keyword("end"));
			
			Rule e22 = new Rule(new NonTerminal("VariableValue")).
				AddSymbol(new NonTerminal("FunctionDefinition"));	
			
			Rule e23 = new Rule(new NonTerminal("FunctionCall")).
			   	AddSymbol(new NonTerminal("Variable")).                 	
			    AddSymbol(new OpenBracket()).
				AddSymbol(new NonTerminal("ParameterValueList"));
			
			Rule e24 = new Rule(new NonTerminal("F")).
				AddSymbol(new NonTerminal("FunctionCall"));
			
			Rule e25 = new Rule(new NonTerminal("ParameterList")).
				AddSymbol(new NonTerminal("ParameterListElements")).
				AddSymbol(new CloseBracket());
			
			Rule e26 = new Rule(new NonTerminal("ParameterList")).
				AddSymbol(new CloseBracket());			
			
			Rule e27 = new Rule(new NonTerminal("SecondParameterListElements")).
				AddSymbol(new NonTerminal("Variable"));

			Rule e28 = new Rule(new NonTerminal("ParameterListElements")).
				AddSymbol(new NonTerminal("ParameterListElements")).
				AddSymbol(new Comma()).
				AddSymbol(new NonTerminal("SecondParameterListElements"));	
			
			Rule e29 = new Rule(new NonTerminal("ParameterListElements")).
				AddSymbol(new NonTerminal("SecondParameterListElements"));				
			
			
			Rule e30 = new Rule(new NonTerminal("ParameterValueList")).
				AddSymbol(new NonTerminal("ParameterListValueElements")).
				AddSymbol(new CloseBracket());
			
			Rule e31 = new Rule(new NonTerminal("ParameterValueList")).
				AddSymbol(new CloseBracket());			
			
			Rule e32 = new Rule(new NonTerminal("SecondParameterListValueElements")).
				AddSymbol(new NonTerminal("E"));

			Rule e33 = new Rule(new NonTerminal("ParameterListValueElements")).
				AddSymbol(new NonTerminal("ParameterListValueElements")).
				AddSymbol(new Comma()).
				AddSymbol(new NonTerminal("SecondParameterListValueElements"));	
			
			Rule e34 = new Rule(new NonTerminal("ParameterListValueElements")).
				AddSymbol(new NonTerminal("SecondParameterListValueElements"));
			
			
			Rule e35 = new Rule(new NonTerminal("AddSubtractOperator")).
				AddSymbol(new Operator("+"));
			
			Rule e36 = new Rule(new NonTerminal("AddSubtractOperator")).
				AddSymbol(new Operator("-"));			
			
			Rule e37 = new Rule(new NonTerminal("MultiplyDivisionOperator")).
				AddSymbol(new Operator("*"));
			
			Rule e38 = new Rule(new NonTerminal("MultiplyDivisionOperator")).
				AddSymbol(new Operator("/"));				
			
			
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
				AddRule(e20).
				AddRule(e21).
				AddRule(e22).
				AddRule(e23).
				AddRule(e24).
				AddRule(e25).
				AddRule(e26).
				AddRule(e27).
				AddRule(e28).
				AddRule(e29).
				AddRule(e30).
				AddRule(e31).
				AddRule(e32).
				AddRule(e33).
				AddRule(e34).
				AddRule(e35).
				AddRule(e36).
				AddRule(e37).
				AddRule(e38);
			
			return grammer;
		}		
	}
}
