using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Emotion.Foundation.LexisAnalysis.Facets;
using Emotion.Foundation.LexisAnalysis.Models;

namespace Emotion.Foundation.LexisAnalysis.Mapping
{
    public class EmotionProfile : Profile
    {
        public EmotionProfile()
        {
            CreateMap<Emotions, EmotionFacet>();
        }
    }
}