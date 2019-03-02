using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emotion.Foundation.LexisAnalysis.Facets;
using Sitecore.XConnect;
using Sitecore.XConnect.Schema;

namespace Emotion.Foundation.LexisAnalysis.Models
{
    public class XConnectEmotionModel
    {
        public static XdbModel Model { get; } = BuildModel();

        private static XdbModel BuildModel()
        {
            XdbModelBuilder modelBuilder = new XdbModelBuilder("XConnectEmotionModel", new XdbModelVersion(0, 1));

            modelBuilder.ReferenceModel(Sitecore.XConnect.Collection.Model.CollectionModel.Model);
            modelBuilder.DefineFacet<Contact, EmotionFacet>(EmotionFacet.DefaultFacetKey);

            return modelBuilder.BuildModel();
        }
    }
}