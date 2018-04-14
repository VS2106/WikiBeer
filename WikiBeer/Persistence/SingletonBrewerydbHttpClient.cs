using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WikiBeer.Persistence
{
    public class SingletonBreweryDbHttpClient
    {
        private static HttpClient _httpClient;
        protected SingletonBreweryDbHttpClient() { }
        public static HttpClient Instance()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient { BaseAddress = new Uri("http://api.brewerydb.com/v2/") };
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }

            return _httpClient;
        }
    }
}