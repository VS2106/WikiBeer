using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WikiBeer.Core.Helpers;
using WikiBeer.Core.Models.BreweryDbResults;

namespace WikiBeer.Core.Models.ViewModels.Beers
{
    public class IndexGet : IndexPost
    {
        public IEnumerable<Beer> Beers { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfResults { get; set; }

        [Display(Name = "Style:", Description = "data-live-search")]
        public new SingleSelectList<Style, int> Style { get; set; }

        [Display(Name = "Sort by:")]
        public new SingleSelectList<BeersSortBy, BeersSortBy> SortBy { get; set; }

        public IndexGet(
            BreweryDbCollectionResult<Beer> breweryDbBeersResult,
            BreweryDbCollectionResult<Style> breweryDbStylesResult,
            int selectedStyle,
            BeersSortBy selectedSortBy,
            string searchName
        )
        {
            Beers = breweryDbBeersResult.Instances;
            CurrentPageNumber = breweryDbBeersResult.CurrentPageNumber;
            TotalNumberOfPages = breweryDbBeersResult.TotalNumberOfPages;
            TotalNumberOfResults = breweryDbBeersResult.TotalNumberOfResults;

            Style = new SingleSelectList<Style, int>(
                breweryDbStylesResult.Instances,
                s => s.Id,
                s => s.Name,
                selectedStyle);
            Style.Items.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "All Style",
                Selected = selectedStyle == 0
            });

            SortBy = new SingleSelectList<BeersSortBy, BeersSortBy>(
                BeersSortByExtension.SortBys,
                o => o,
                o => o.GetName(),
                selectedSortBy);
            SearchName = searchName;
        }
    }
}