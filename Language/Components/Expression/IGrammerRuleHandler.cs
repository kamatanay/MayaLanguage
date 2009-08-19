
using System;

namespace Components
{
	public interface IGrammerRuleHandler
	{
		void HandleRule(int ruleId);
		TreeNodeStack TreeNodeStack {set;}
	}
}
