using Emotion.Foundation.LexisAnalysis.Facets;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Tracking;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Client.Configuration;
using Contact = Sitecore.XConnect.Contact;

namespace Emotion.Foundation.LexisAnalysis.Services
{
    public class XConnectService : IXConnectService
    {
        /// <summary>
        /// Set emotion facet to contact
        /// </summary>
        /// <param name="contact">Contact to be updated</param>
        /// <param name="facet">Facet to be applied to Contact</param>
        public void SetEmotionFacet(Contact contact, EmotionFacet facet)
        {
            using (var client = SitecoreXConnectClientConfiguration.GetClient())
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

        /// <summary>
        /// Get current contact
        /// </summary>
        /// <returns>Current XConnect.Contact with EmotionFacet</returns>
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
                        new ContactExpandOptions(EmotionFacet.DefaultFacetKey));

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