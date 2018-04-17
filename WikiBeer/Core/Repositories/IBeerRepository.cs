using System.Threading.Tasks;
using WikiBeer.Core.Models;
using WikiBeer.Core.Models.BreweryDbResults;
using WikiBeer.Core.Repositories.Base;

namespace WikiBeer.Core.Repositories
{
    public interface IBeerRepository : IBreweryDbBaseRepository<Beer, string>
    {
        Task<BreweryDbCollectionResult<Brewery>> GetBreweries(string beerId);
    }
}
