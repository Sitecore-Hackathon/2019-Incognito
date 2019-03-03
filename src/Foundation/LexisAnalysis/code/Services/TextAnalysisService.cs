using System;
using Emotion.Foundation.LexisAnalysis.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace Emotion.Foundation.LexisAnalysis.Services
{
    public class TextAnalysisService : ITextAnalysisService
    {
        /// <summary>
        /// Communicate with Python web server via API. 
        /// </summary>
        /// <param name="request">Text to analyze</param>
        /// <returns></returns>
        public LexisAnalysisResponse GetEmotions(LexisAnalysisRequest request)
        {
            try
            {
                var client = new RestClient(LexisServerApiUrl);
                var restRequest = new RestRequest("", Method.POST);

                DefaultContractResolver contractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
                restRequest.AddParameter("application/json", JsonConvert.SerializeObject(request,
                        new JsonSerializerSettings()
                        {
                            ContractResolver = contractResolver
                        }),
                    ParameterType.RequestBody);

                var response = client.Execute(restRequest);
                if (response.IsSuccessful)
                {
                    var resp = JsonConvert.DeserializeObject<LexisAnalysisResponse>(response.Content);
                    return resp;
                }

                throw new Exception($"Request was failed with code: {response.StatusCode}, message: {response.Content}");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get emotions from server", ex);
            }
        }

        public virtual string LexisServerApiUrl => Sitecore.Configuration.Settings.GetSetting(Constants.Settings.LexisTextAnalysisServerUrl);
    }
}