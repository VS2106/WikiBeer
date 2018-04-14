using WikiBeer.Core.Models;
using WikiBeer.Core.Repositories;
using WikiBeer.Persistence.Repositories.Base;

namespace WikiBeer.Persistence.Repositories
{
    public class BreweryRepository : BreweryDbBaseRepository<Brewery, string>, IBreweryRepository
    {
        public BreweryRepository() : base("brewery", "breweries")
        {
        }
    }
}