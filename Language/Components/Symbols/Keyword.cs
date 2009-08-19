
using System;

namespace Components
{
	public class Keyword:ISymbol
	{
		private string keyword;
		
		public Keyword(string keyword)
		{
			this.keyword = keyword;
		}
		
		public ISymbol Duplicate(){
			return new Keyword(keyword);
		}
		
		public override bool Equals (object obj)
		{
			Keyword objectSymbol = obj as Keyword;
			return objectSymbol != null && objectSymbol.ToString().Equals(ToString());
		}
		
		public override int GetHashCode ()
		{
			return (this.GetType().ToString()+this.ToString()).GetHashCode();
		}
		
		public object Value(){
			return null;
		}	
		
		public bool IsEndSymbol(){
			return false;
		}
		
		public bool IsNonTerminal(){
			return false;
		}
		
		public override string ToString(){
			return keyword;
		}				
	}
}
