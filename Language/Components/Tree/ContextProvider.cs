
using System;

namespace Components
{
	public class ContextProvider
	{		
		private static Context context = null;
		
		public static Context GetContext(){
			if (context == null)
				context = new Context();
			return context;
		}
	}
}
