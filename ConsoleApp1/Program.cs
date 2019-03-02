using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emotion.Foundation.LexisAnalysis.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = Sitecore.XConnect.Serialization.XdbModelWriter.Serialize(XConnectEmotionModel.Model);
            File.WriteAllText(XConnectEmotionModel.Model.FullName + ".json ", model);
        }
    }
}
