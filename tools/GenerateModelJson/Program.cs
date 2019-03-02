using System.IO;
using Emotion.Foundation.LexisAnalysis.Models;

namespace GenerateModelJson
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
