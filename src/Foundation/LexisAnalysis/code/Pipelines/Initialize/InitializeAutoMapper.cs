using AutoMapper;
using Emotion.Foundation.LexisAnalysis.Mapping;
using Sitecore.Pipelines;

namespace Emotion.Foundation.LexisAnalysis.Pipelines.Initialize
{
    public class InitializeAutoMapper
    {
        public void Process(PipelineArgs args)
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<EmotionProfile>(); });
        }
    }
}