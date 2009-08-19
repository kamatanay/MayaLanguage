
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Components
{
	public class States
	{
		public static States BuildStates(Grammer grammer){
			States states = new States(grammer);
			states = states.BuildStates();
			states.BuildMap();
			return states;
		}
		
		private ArrayList states;
		private Grammer grammer;
		private Dictionary<int,Dictionary<ISymbol,IAction>> actionMap;
		
		private States(Grammer grammer)
		{
			states = new ArrayList();
			this.grammer = grammer;
			actionMap = new Dictionary<int, Dictionary<ISymbol, IAction>>();
		}
		
		private States BuildStates(){
			AddState(grammer.GetInitialState());
			return BuildStates(0);
		}
		
		private States BuildStates(int stateIndex){
			Set currentSet = (Set)states[stateIndex];
			actionMap[stateIndex] = new Dictionary<ISymbol, IAction>();
			foreach(ISymbol symbol in currentSet.GetSymbolsForGoto()){
				Set gotoState = currentSet.Goto(symbol);
				AddState(gotoState);
				if (symbol.IsNonTerminal())
					actionMap[stateIndex][symbol] = new Go(GetStateIdFor(gotoState));
				else
					actionMap[stateIndex][symbol] = new Shift(GetStateIdFor(gotoState));
			}
			if ((states.Count-1)>stateIndex)
				return BuildStates(stateIndex+1);
			return this;
		}
		
		private void BuildMap(){
			for(int index=0;index<states.Count;index++){
				Set currentSet = (Set)states[index];
				if (currentSet.IsFinalState){
					actionMap[index][new End()] = new Accept();
				}				
				if (currentSet.ReduceStateId<=0)
					continue;
				foreach(ISymbol grammerSymbol in this.grammer.SymbolsInGrammer){
					if (!grammerSymbol.IsNonTerminal()){
						if (!actionMap[index].ContainsKey(grammerSymbol))
							actionMap[index][grammerSymbol] = new Reduce(currentSet.ReduceStateId,grammer,this);
					}	
				}
			}
		}

		private int GetStateIdFor(Set gotoState){
			for (int index=0;index<states.Count;index++){
				Set currentState = (Set)states[index];
				if (currentState.ToString().Equals(gotoState.ToString()))
					return index;
			}
			return -1;
		}
		
		public IAction GetAction(int stateId, ISymbol symbol){
			try{
				return actionMap[stateId][symbol];
			}
			catch(KeyNotFoundException e){
			 Console.WriteLine(stateId+" "+symbol.ToString());
				return null;
			}
		}
		
		public int Count(){
			return states.Count;
		}
		
		public void AddState(Set stateSet){
			if (!StateExists(stateSet))
				states.Add(stateSet);
		}
		
		public bool StateExists(Set stateSet){
			foreach(Object setObject in states){
				Set currentSet = (Set)setObject;
				if (stateSet.ToString().Equals(currentSet.ToString()))
					return true;
			}
			return false;
		}
		
		public override string ToString(){
			string statesString = "";
			for(int index=0;index<states.Count;index++){
				statesString = statesString + index + " " + states[index].ToString().Replace("$","\n");
				statesString = statesString + "\n\n";
			}
			return statesString;
		}
	}
}
