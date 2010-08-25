
using System;
using System.Collections;
using Components;
using System.Text.RegularExpressions;

namespace MayaLanguage
{
	public class Input:IInput
	{
		private ArrayList inputs;
		private int position;
		private ISymbol lastReadElement;
		private string program;
		private int textPosition;
		private int lineNumber;
		private ArrayList keywords;
		
		public ISymbol LastReadElement{
			get{return lastReadElement;}
			set{lastReadElement = value;}
		}
		
		public Input(string programText)
		{
			inputs = new ArrayList();
			position = 0;
			textPosition = 0;
			program = programText;
			lineNumber = 1;
			IntializeKeywords();
		}
		
		private void IntializeKeywords(){
			keywords = new ArrayList();
			keywords.Add("print");
			keywords.Add("if");
			keywords.Add("else");
			keywords.Add("end");
			keywords.Add("var");
			keywords.Add("function");
		}
		
		public ISymbol Get(){
			if (((ISymbol)inputs[position]).Value() != null)
				LastReadElement = (ISymbol)inputs[position];
			return (ISymbol)inputs[position];
		}
		
		public void Next(){
			position++;
		}
		
		public void Parse(){
			while(textPosition != program.Length){	
				switch(program[textPosition]){
					case ' ' : 	textPosition++;break;
					case '\t':	textPosition++;break;
					case '\n':	textPosition++; lineNumber++;break;
					case '\r':	textPosition++;break;
					case ',' :	inputs.Add(new Comma());textPosition++;break;
					case '+' :	inputs.Add(new Operator("+"));textPosition++;break;
					case '-' :	inputs.Add(new Operator("-"));textPosition++;break;
					case '=' : 	inputs.Add(new Operator("="));textPosition++;break;
					case '*' :	inputs.Add(new Operator("*"));textPosition++;break;
					case '/' :	inputs.Add(new Operator("/"));textPosition++;break;
					case ';' :	inputs.Add(new Semicolon());textPosition++;break;
					case '(' :	inputs.Add(new OpenBracket());textPosition++;break;
					case ')' :	inputs.Add(new CloseBracket());textPosition++;break;
					case '"' : int currentPosition = textPosition++;
								int length = 0;
								while(program[textPosition] != '"'){
									textPosition++;
									length++;
								}
								string stringLiteral = program.Substring(currentPosition+1,length);
								textPosition++;
								inputs.Add(new Literal(stringLiteral));break;
					default:	string subString = program.Substring(textPosition);
								Regex regex = new Regex("^([a-zA-Z0-9]+)");
								Match match = regex.Match(subString);
								if (!match.Success)
									throw new Exception(string.Format("Error [{0}]: Invalid tocken identified",lineNumber));
								string identifiedPart = match.Groups[1].Value.ToString();
								textPosition += identifiedPart.Length;
								int number;
								if (int.TryParse(identifiedPart,out number)){
									inputs.Add(new Literal(number));
									break;
								}
								if (keywords.Contains(identifiedPart)){
									inputs.Add(new Keyword(identifiedPart));
									break;
								}
								else{
									inputs.Add(new Identifier(identifiedPart));
									break;
								}
				}
			}
			inputs.Add(new End());
		}
	}
}
