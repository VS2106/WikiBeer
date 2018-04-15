using System;
using System.Collections.Generic;
using System.Linq;
using WikiBeer.Core.Helpers;
using WikiBeer.Core.Models.BrewerDbResults;

namespace WikiBeer.Core.Models.ViewModels.Beers
{
    public class IndexGet : IndexPost
    {
        public IEnumerable<Beer> Beers { get; set; }
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfResults { get; set; }
        public new SingleSelectList<Style, int> Style { get; set; }
        public new SingleSelectList<BeersOrderBy, BeersOrderBy> OrderBy { get; set; }

        public IndexGet(
            BrewerDbCollectionResult<Beer> brewerDbBeersResult,
            BrewerDbCollectionResult<Style> brewerDbStylesResult,
            int selectedStyle,
            BeersOrderBy selectedOrderBy,
            bool isSortAsc,
            string searchName
        )
        {
            Beers = brewerDbBeersResult.Objects;
            CurrentPageNumber = brewerDbBeersResult.CurrentPageNumber;
            TotalNumberOfPages = brewerDbBeersResult.TotalNumberOfPages;
            TotalNumberOfResults = brewerDbBeersResult.TotalNumberOfResults;

            Style = new SingleSelectList<Style, int>(
                brewerDbStylesResult.Objects,
                s => s.Id,
                s => s.Name,
                selectedStyle);
            Style.Items.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "All Style",
                Selected = selectedStyle == 0
            });

            OrderBy = new SingleSelectList<BeersOrderBy, BeersOrderBy>(
                Enum.GetValues(typeof(BeersOrderBy)).Cast<BeersOrderBy>(),
                o => o,
                o => o.ToString(),
                selectedOrderBy);
            IsSortAsc = isSortAsc;
            SearchName = searchName;
        }
    }
}