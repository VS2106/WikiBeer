using System.Threading.Tasks;
using WikiBeer.Core.Models;
using WikiBeer.Core.Models.BrewerDbResults;
using WikiBeer.Core.Repositories.Base;

namespace WikiBeer.Core.Repositories
{
    public interface IBeerRepository : IBreweryDbBaseRepository<Beer, string>
    {
        Task<BrewerDbCollectionResult<Brewery>> GetBreweries(string beerId);
    }
}
