using WikiBeer.Core.Models;
using WikiBeer.Core.Repositories.Base;

namespace WikiBeer.Core.Repositories
{
    public interface IStyleRepository : IBreweryDbBaseRepository<Style, int>
    {
    }
}