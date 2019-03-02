using System;
using System.Collections.Generic;
using System.Linq;
using Emotion.Foundation.LexisAnalysis.Enum;
using Emotion.Foundation.LexisAnalysis.Services;
using Sitecore.Data;
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
            var manager = new EmotionManager();
            var item = Sitecore.Context.Database.GetItem(new ID(Value));
            var contactFeeling = manager.GetFeeling();
            if (Enum.TryParse(item.Name, true, out Feelings parameterfeeling))
            {
                return contactFeeling == parameterfeeling;
            }
            return false;
        }
    }
}