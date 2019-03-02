using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Emotion.Feature.Rules.Rules
{
    public class FeelingCondition <T> : StringOperatorCondition<T> where T : RuleContext
    {
        public string Value
        {
            get;
            set;
        }

        protected override bool Execute(T ruleContext)
        {
            throw new NotImplementedException();
        }
    }
}