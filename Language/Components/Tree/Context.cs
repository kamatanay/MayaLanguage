
using System;
using System.Collections;
using System.Collections.Generic;

namespace Components
{
	public class Context
	{
		private ArrayList contexts;
			
		public Context()
		{
			contexts = new ArrayList();
		}
		
		public void SetContexts(params Dictionary<string,object>[] contextObjects){
			foreach (Dictionary<string,object> contextObject in contextObjects) {
				this.contexts.Add(contextObject);
			}
		}
		
		public object GetValueOf(string variableName){
			for (int index=this.contexts.Count-1;index>=0;index--) {
				object contextObject = this.contexts[index];
				Dictionary<string,object> context = contextObject as Dictionary<string,object>;
				if (context.ContainsKey(variableName))
					return context[variableName];
			}
			return null;
		}
		
		public void SetValueOf(string variableName,object valueObject){
			((Dictionary<string,object>)contexts[contexts.Count-1])[variableName] = valueObject;
		}
		
		public void CreateNewContext(){
			this.contexts.Add(new Dictionary<string,object>());
		}
		
		public void DeleteRecentContext(){
			if (this.contexts.Count>1)
				this.contexts.RemoveAt(this.contexts.Count-1);
		}		
	}
}
