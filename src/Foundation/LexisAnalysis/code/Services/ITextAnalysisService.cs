using Emotion.Foundation.LexisAnalysis.Models;

namespace Emotion.Foundation.LexisAnalysis.Services
{
    public interface ITextAnalysisService
    {
        string LexisServerApiUrl { get; }

        LexisAnalysisResponse GetEmotions(LexisAnalysisRequest request);
    }
}