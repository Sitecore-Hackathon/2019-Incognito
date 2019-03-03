using Emotion.Foundation.LexisAnalysis.Enum;
using Sitecore.XConnect;

namespace Emotion.Foundation.LexisAnalysis.Services
{
    public interface IEmotionManager
    {
        void FillEmotionFacet(string text, Contact contact = null);
        Feelings GetFeeling(Contact contact = null);
    }
}