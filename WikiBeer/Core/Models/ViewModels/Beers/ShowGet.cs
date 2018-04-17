using System.Collections.Generic;

namespace WikiBeer.Core.Models.ViewModels.Beers
{
    public class ShowGet
    {
        public Beer Beer { get; set; }
        public IEnumerable<Brewery> Breweries { get; set; }
        public ShowGet(Beer beer,
            IEnumerable<Brewery> breweries)
        {
            Beer = beer;
            Breweries = breweries;
        }
    }
}