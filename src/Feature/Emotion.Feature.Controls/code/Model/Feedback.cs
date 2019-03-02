using System.ComponentModel;

namespace Emotion.Feature.Rules.Model
{
    public class Feedback
    {
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Feedback")]
        public string Text { get; set; }
    }
}