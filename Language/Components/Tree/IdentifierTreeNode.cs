
using System;
using System.Collections.Generic;

namespace Components
{
	public class IdentifierTreeNode:ITreeNode
	{		
		private ISymbol identifierName;
		private Dictionary<string,object> identifierMap;
		
		public IdentifierTreeNode(ISymbol identifierName, Dictionary<string,object> identifierMap)
		{
			this.identifierName = identifierName;
			this.identifierMap = identifierMap;
		}
		
		public ISymbol IdentifierName{
			get{
				return identifierName;
			}
		}
		
		public ISymbol Execute(){
			ISymbol symbol = identifierMap[identifierName.Value().ToString()] as ISymbol;
			return symbol;
		}		
	}
}
