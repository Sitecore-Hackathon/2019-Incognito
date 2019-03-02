using System;
using Sitecore.XConnect;

namespace Emotion.Foundation.LexisAnalysis.Facets
{
    [Serializable]
    [FacetKey(DefaultFacetKey)]
    public class EmotionFacet : Facet
    {
        public const string DefaultFacetKey = "EmotionFacet";

        // ReSharper disable once EmptyConstructor
        // All facets must declare an empty constructor - this is an oData restriction. The constructor can be private.
        public EmotionFacet()
        {

        }

        public string Feeling { get; set; }

        public float Anger { get; set; }
        public float Disgust { get; set; }
        public float Fear { get; set; }
        public float Happiness { get; set; }
        public float Neutral { get; set; }
        public float Sadness { get; set; }
        public float Surprise { get; set; }
    }
}