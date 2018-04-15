using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WikiBeer.Core.Repositories;

namespace WikiBeer.Controllers
{
    public class BeersController : Controller
    {
        private readonly Lazy<IBeerRepository> _beerRepo;
        private readonly Lazy<IStyleRepository> _styleRepo;

        public BeersController(Lazy<IBeerRepository> beerRepo,
            Lazy<IStyleRepository> styleRepo)
        {
            _beerRepo = beerRepo;
            _styleRepo = styleRepo;
        }

        public async Task<ActionResult> Index()
        {
            var beers = await _beerRepo.Value.GetAllAsync();
            var styles = await _styleRepo.Value.GetAllAsync();
            return new EmptyResult();
        }
    }
}