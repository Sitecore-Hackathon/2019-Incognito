using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emotion.Foundation.LexisAnalysis.Facets;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Tracking;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.Configuration;
using Sitecore.XConnect.Collection.Model;
using Contact = Sitecore.XConnect.Contact;

namespace Emotion.Foundation.LexisAnalysis.Services
{
    public class XConnectService : IXConnectService
    {
        public void SetEmotionFacet(Contact contact, EmotionFacet facet)
        {
            using (var client = Sitecore.XConnect.Client.Configuration.SitecoreXConnectClientConfiguration.GetClient())
            {
                try
                {
                    var emotions = contact.GetFacet<EmotionFacet>(EmotionFacet.DefaultFacetKey);
                    if (emotions == null)
                    {
                        client.SetFacet(contact, EmotionFacet.DefaultFacetKey, facet);
                    }
                    else
                    {
                        UpdateFacetValues(facet, emotions);
                        client.SetFacet(contact, EmotionFacet.DefaultFacetKey, emotions);
                    }
                    
                    client.Submit();
                }
                catch (XdbExecutionException ex)
                {
                    Log.Error($"Could not set facet for {contact.Id} contact", ex, this);
                }
            }
        }

        private static void UpdateFacetValues(EmotionFacet facet, EmotionFacet emotions)
        {
            emotions.Anger = facet.Anger;
            emotions.Disgust = facet.Disgust;
            emotions.Fear = facet.Fear;
            emotions.Feeling = facet.Feeling;
            emotions.Happiness = facet.Happiness;
            emotions.Neutral = facet.Neutral;
            emotions.Sadness = facet.Sadness;
            emotions.Surprise = facet.Surprise;
        }

        public Contact GetCurrentContact()
        {
            if (Factory.CreateObject("tracking/contactManager", true) is ContactManager manager)
            {
                using (var client = SitecoreXConnectClientConfiguration.GetClient())
                {

                    var trackerIdentifier = new IdentifiedContactReference(
                        Sitecore.Analytics.XConnect.DataAccess.Constants.IdentifierSource,
                        Sitecore.Analytics.Tracker.Current.Contact.ContactId.ToString("N"));

                    var contact = client.Get<Contact>(trackerIdentifier,
                        new Sitecore.XConnect.ContactExpandOptions(EmotionFacet.DefaultFacetKey));

                    if (contact == null)
                    {
                        manager.CreateContact(ID.NewID);
                    }

                    if (Sitecore.Analytics.Tracker.Current.Contact.IsNew)
                    {
                        Sitecore.Analytics.Tracker.Current.Contact.ContactSaveMode = ContactSaveMode.AlwaysSave;
                        manager.SaveContactToCollectionDb(Sitecore.Analytics.Tracker.Current.Contact);
                    }

                    return contact;
                }
            }
            return null;
        }
    }
}