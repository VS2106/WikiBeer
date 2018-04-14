using WikiBeer.Core.Models;
using WikiBeer.Core.Repositories;
using WikiBeer.Persistence.Repositories.Base;

namespace WikiBeer.Persistence.Repositories
{
    public class StyleRepository : BreweryDbBaseRepository<Style, int>, IStyleRepository
    {
        public StyleRepository() : base("style", "styles")
        {
        }
    }
}