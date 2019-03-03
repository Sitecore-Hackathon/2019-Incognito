using Emotion.Foundation.LexisAnalysis.Models;
using Emotion.Foundation.LexisAnalysis.Services;
using NSubstitute;
using NUnit.Framework;

namespace Emotion.Foundation.LexisAnalysis.Tests.Tests
{
    [TestFixture]
    public class TextAnalytsServiceIntegrationTest
    {

        [TestCase("You must have AWS experience, preferably Azure", "neutral")]
        [TestCase("Animals in the forest", "disgust")]
        [TestCase("Wow Wow \nI am surprised", "surprise")]
        public void IncompleteContent(string text, string feeling)
        {
            var service = Substitute.For<TextAnalysisService>();
            service.LexisServerApiUrl.Returns("http://localhost:8080/api/predict");
            var request = new LexisAnalysisRequest() {Input = text};
            var response = service.GetEmotions(request);
            Assert.AreEqual(feeling, response.Response.Feeling);
        }
    }
}
