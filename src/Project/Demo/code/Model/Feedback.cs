using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Emotion.Project.Demo.Model
{
    public class Feedback
    {
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Feedback")]
        public string Text { get; set; }
    }
}