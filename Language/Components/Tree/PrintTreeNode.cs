
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
			ISymbol valueSymbol = valueNode.Execute();
			if (valueSymbol.GetType().Equals(typeof(Identifier)))
			    valueSymbol = (ISymbol)ContextProvider.GetContext().GetValueOf(valueSymbol.Value().ToString());			
			Console.WriteLine(valueSymbol.Value().ToString());
			return valueSymbol;
		}	
	}
}
