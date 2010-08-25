using System;
using Components;
using System.IO;

namespace MayaLanguage
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length == 0){
				Console.WriteLine("Maya: A simple language created by Anay Narendra Kamat (For learning purpose only).");
				Console.WriteLine("You need to specify a file path.");
				Console.WriteLine();
				return;
			}
			
			string programInput = File.ReadAllText(args[0]);
			
			GrammerBuilder grammerBuilder = new GrammerBuilder();
			Grammer grammer = grammerBuilder.GetGrammer();
			IInput input = new Input(programInput);
			Parser parser = new Parser();
			IGrammerRuleHandler ruleHandler = new GrammerRuleHandler(input);
			ITreeNode rootNode = parser.Parse(grammer,input,ruleHandler);
			rootNode.Execute();
		}
	}
}