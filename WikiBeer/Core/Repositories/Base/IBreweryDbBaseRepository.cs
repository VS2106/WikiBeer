using System.Collections.Generic;
using System.Threading.Tasks;
using WikiBeer.Core.Models.BrewerDbResults;

namespace WikiBeer.Core.Repositories.Base
{
    public interface IBreweryDbBaseRepository<T, in TResourceIdentifier> where T : class
    {
        Task<BrewerDbCollectionResult<T>> GetAllAsync(params KeyValuePair<string, string>[] parameters);
        Task<BrewerDbSingelResult<T>> GetAsync(TResourceIdentifier identifier);

        Task<BrewerDbCollectionResult<TDetailType>> GetDetailCollectionAsync<TDetailType>(
            TResourceIdentifier identifier,
            string detailResourceNamePlural)
            where TDetailType : class;

        Task<BrewerDbSingelResult<TDetailType>> GetDetailAsync<TDetailType>(
            TResourceIdentifier identifier,
            string detailResourceNameSingular)
            where TDetailType : class;

        Task<BrewerDbSingelResult<T>> AddAsync(T model);
        Task<bool> UpdateAsync(TResourceIdentifier identifier, T model);
        Task<bool> DeleteAsync(TResourceIdentifier identifier);
    }
}