using System;
using Components;
using System.IO;

namespace Language
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if (args.Length == 0){
				Console.WriteLine("Language: A simple language created by Anay Kamat (For learning purpose only).");
				Console.WriteLine("You need to specify a file path.");
				Console.WriteLine();
				return;
			}
			
			string programInput = File.ReadAllText(args[0]);
			
			IInput input = new Input(programInput);
			Parser parser = new Parser();
			ITreeNode rootNode = parser.Parse(input);
			rootNode.Execute();
		}
	}
}