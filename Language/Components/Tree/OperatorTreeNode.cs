
using System;

namespace Components
{	
	public class OperatorTreeNode:ITreeNode
	{
		private Operator operatorSymbol;
			
		public OperatorTreeNode(Operator operatorSymbol)
		{
			this.operatorSymbol = operatorSymbol;
		}
		
		public ISymbol Execute(){
			return operatorSymbol;
		}
	}
}
