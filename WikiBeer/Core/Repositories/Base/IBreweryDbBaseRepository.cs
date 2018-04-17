using System.Collections.Generic;
using System.Threading.Tasks;
using WikiBeer.Core.Models.BreweryDbResults;

namespace WikiBeer.Core.Repositories.Base
{
    public interface IBreweryDbBaseRepository<T, in TResourceIdentifier> where T : class
    {
        Task<BreweryDbCollectionResult<T>> GetAllAsync(params KeyValuePair<string, string>[] parameters);
        Task<BreweryDbSingelResult<T>> GetAsync(TResourceIdentifier identifier);

        Task<BreweryDbCollectionResult<TDetailType>> GetDetailCollectionAsync<TDetailType>(
            TResourceIdentifier identifier,
            string detailResourceNamePlural)
            where TDetailType : class;

        Task<BreweryDbSingelResult<TDetailType>> GetDetailAsync<TDetailType>(
            TResourceIdentifier identifier,
            string detailResourceNameSingular)
            where TDetailType : class;

        Task<BreweryDbSingelResult<T>> AddAsync(T model);
        Task<bool> UpdateAsync(TResourceIdentifier identifier, T model);
        Task<bool> DeleteAsync(TResourceIdentifier identifier);
    }
}