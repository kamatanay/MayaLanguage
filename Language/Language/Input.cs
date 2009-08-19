
using System;
using System.Collections;
using Components;
using System.Text.RegularExpressions;

namespace Language
{
	public class Input:IInput
	{
		private ArrayList inputs;
		private int position;
		private ISymbol lastReadElement;
		private string program;
		private int textPosition;
		
		public ISymbol LastReadElement{
			get{return lastReadElement;}
			set{lastReadElement = value;}
		}
		
		public Input()
		{
			inputs = new ArrayList();
			position = 0;
			textPosition = 0;
			program="print 5+5*10;print 10;print 5*5+10;";
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
					case '+' :	inputs.Add(new Operator("+"));textPosition++;break;
					case '*' :	inputs.Add(new Operator("*"));textPosition++;break;
					case ';' :	inputs.Add(new Semicolon());textPosition++;break;
					default:	string subString = program.Substring(textPosition);
								Regex regex = new Regex("^([a-z0-9]+)");
								Match match = regex.Match(subString);
								if (!match.Success)
									throw new Exception("Invalid tocken identified");
								string identifiedPart = match.Groups[1].Value.ToString();
								textPosition += identifiedPart.Length;
								int number;
								if (int.TryParse(identifiedPart,out number)){
									inputs.Add(new Literal(number));
									break;
								}
								if (identifiedPart.Equals("print")){
									inputs.Add(new Keyword("print"));
									break;
								}
								else{
									throw new Exception("tocken not recognized "+identifiedPart);
								}
				}
			}
			inputs.Add(new End());
		}
	}
}
