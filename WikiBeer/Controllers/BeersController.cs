using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WikiBeer.Core.Models.ViewModels.Beers;
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

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var beers = await _beerRepo.Value.GetAllAsync();
            var styles = await _styleRepo.Value.GetAllAsync();
            return View(new IndexGet(beers, styles, 0, BeersSortBy.NameAsc, string.Empty));
        }

        [HttpPost]
        public async Task<ActionResult> Index(IndexPost context)
        {
            var beers = await _beerRepo.Value.GetAllAsync(context.GetQuery());
            var styles = await _styleRepo.Value.GetAllAsync();
            return PartialView("IndexContent", new IndexGet(beers, styles, context.Style, context.SortBy, context.SearchName));
        }

        [HttpGet]
        public async Task<ActionResult> Show(string id)
        {
            var beer = await _beerRepo.Value.GetAsync(id);
            if (beer == null) return new EmptyResult();

            var breweriesOfBeer = await _beerRepo.Value.GetBreweries(id);
            return View(new ShowGet(beer.Instance, breweriesOfBeer.Instances));
        }
    }
}