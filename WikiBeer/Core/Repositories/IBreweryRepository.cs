using WikiBeer.Core.Models;
using WikiBeer.Core.Repositories.Base;

namespace WikiBeer.Core.Repositories
{
    public interface IBreweryRepository : IBreweryDbBaseRepository<Brewery, string>
    {
    }
}