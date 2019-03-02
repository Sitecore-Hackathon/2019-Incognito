using Emotion.Foundation.LexisAnalysis.Facets;
using Sitecore.XConnect;

namespace Emotion.Foundation.LexisAnalysis.Services
{
    public interface IXConnectService
    {
        void SetEmotionFacet(Contact contact, EmotionFacet facet);
        Contact GetCurrentContact();
    }
}