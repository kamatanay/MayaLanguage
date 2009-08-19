
using System;

namespace Components
{
	public class PrintTreeNode:ITreeNode
	{	
		private ITreeNode valueNode;
		
		public PrintTreeNode(ITreeNode valueNode)
		{
			this.valueNode = valueNode;
		}
		
		public ISymbol Execute(){
			Console.WriteLine(valueNode.Execute().Value().ToString());
			return valueNode.Execute();
		}	
	}
}
