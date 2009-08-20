
using System;
using System.Collections;
using System.Collections.Generic;

namespace Components
{
	public class Context
	{
		private ArrayList contexts;
		private IDictionary<int, string> parameterVariableNames;
		private IDictionary<int, object> parameterValues;
			
		public Context()
		{
			contexts = new ArrayList();
			parameterVariableNames = new Dictionary<int,string>();
			parameterValues = new Dictionary<int, object>();
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
		
		public void AddParameterName(string parameterName){
			parameterVariableNames[parameterVariableNames.Keys.Count] = parameterName;
		}
		
		public void AddParameterValue(object parameterValue){
			parameterValues[parameterValues.Keys.Count] = parameterValue;
		}		
		
		public void CopyToVariableTable(){
			int countOfVariables = parameterVariableNames.Keys.Count;
			for (int index=0;index < countOfVariables;index++){
				((Dictionary<string,object>)this.contexts[this.contexts.Count-1])[parameterVariableNames[index]] = parameterValues[index];
			}
			parameterVariableNames.Clear();
			parameterValues.Clear();	
		}
	}
}
