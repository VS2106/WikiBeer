using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WikiBeer.Core.Models.BreweryDbResults;
using WikiBeer.Core.Repositories.Base;

namespace WikiBeer.Persistence.Repositories.Base
{
    public abstract class
        BreweryDbBaseRepository<T, TResourceIdentifier> : IBreweryDbBaseRepository<T, TResourceIdentifier>
        where T : class
    {
        private const string APiKey = "ee8a1a84bc76fd7d7ae6dd0dc45583e3";
        private readonly string _resourceNameSingular;
        private readonly string _resourceNamePlural;

        protected BreweryDbBaseRepository(string resourceNameSingular,
            string resourceNamePlural)
        {
            _resourceNameSingular = resourceNameSingular;
            _resourceNamePlural = resourceNamePlural;
        }

        public async Task<BreweryDbCollectionResult<T>> GetAllAsync(params KeyValuePair<string, string>[] parameters)
        {
            var response = await GetHttpClient()
                .GetAsync($"{_resourceNamePlural}/?key={APiKey}{BuildParametersList(parameters)}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<BreweryDbCollectionResult<T>>();
        }

        public async Task<BreweryDbSingelResult<T>> GetAsync(TResourceIdentifier identifier)
        {
            var response = await GetHttpClient()
                .GetAsync($"{_resourceNameSingular}/{identifier}/?key={APiKey}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<BreweryDbSingelResult<T>>();
            return null;
        }

        public async Task<BreweryDbCollectionResult<TDetailType>> GetDetailCollectionAsync<TDetailType>(
            TResourceIdentifier identifier,
            string detailResourceNamePlural)
            where TDetailType : class
        {
            var response = await GetHttpClient()
                .GetAsync($"{_resourceNameSingular}/{identifier}/{detailResourceNamePlural}/?key={APiKey}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<BreweryDbCollectionResult<TDetailType>>();
            return null;
        }

        public async Task<BreweryDbSingelResult<TDetailType>> GetDetailAsync<TDetailType>(
            TResourceIdentifier identifier,
            string detailResourceNameSingular)
            where TDetailType : class
        {
            var response = await GetHttpClient()
                .GetAsync($"{_resourceNameSingular}/{identifier}/{detailResourceNameSingular}/?key={APiKey}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<BreweryDbSingelResult<TDetailType>>();
            return null;
        }

        //TODO later: Add/Update/Delte are not required by the coding challenge
        public async Task<BreweryDbSingelResult<T>> AddAsync(T model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(TResourceIdentifier identifier, T model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAsync(TResourceIdentifier identifier)
        {
            throw new System.NotImplementedException();
        }

        private static HttpClient GetHttpClient()
        {
            return SingletonBreweryDbHttpClient.Instance();
        }

        private static string BuildParametersList(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var stringBuilder = new StringBuilder();

            foreach (var parameter in parameters)
            {
                stringBuilder.Append($"&{parameter.Key}={Uri.EscapeDataString(parameter.Value)}");
            }

            return stringBuilder.ToString();
        }
    }
}