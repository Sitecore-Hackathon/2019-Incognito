using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Emotion.Foundation.LexisAnalysis.Enum;
using Emotion.Foundation.LexisAnalysis.Facets;
using Emotion.Foundation.LexisAnalysis.Models;
using Sitecore.XConnect;

namespace Emotion.Foundation.LexisAnalysis.Services
{
    public class EmotionManager
    {
        private ITextAnalysisService _analysisService;
        private IXConnectService _xConnectService;
        private IMapper _mapper;

        public EmotionManager()
        {
            _analysisService = new TextAnalysisService();
            _xConnectService = new XConnectService();
            _mapper = new Mapper(Mapper.Configuration);
        }

        public EmotionManager(ITextAnalysisService textAnalysisService, IXConnectService xConnectService, IMapper mapper)
        {
            _xConnectService = xConnectService;
            _analysisService = textAnalysisService;
            _mapper = mapper;
        }

        public void FillEmotionFacet(string text, Contact contact = null)
        {
            var analysis = _analysisService.GetEmotions(new LexisAnalysisRequest() {Input = text});
            var facet = _mapper.Map<EmotionFacet>(analysis.Response);
            if (contact == null)
            {
                contact = _xConnectService.GetCurrentContact();
            }
            _xConnectService.SetEmotionFacet(contact, facet);
        }

        public Feelings GetFeeling(Contact contact = null)
        {
            if (contact == null)
            {
                contact = _xConnectService.GetCurrentContact();
            }

            var emotions = contact.GetFacet<EmotionFacet>(EmotionFacet.DefaultFacetKey);
            if (emotions != null)
            {
                if (System.Enum.TryParse(emotions.Feeling, true, out Feelings myStatus))
                {
                    return myStatus;
                }
            }

            return Feelings.NotAvailable;
        }
    }
}