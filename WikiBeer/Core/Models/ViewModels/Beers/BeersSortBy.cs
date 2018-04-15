using System;
using System.Linq;

namespace WikiBeer.Core.Models.ViewModels.Beers
{
    public enum BeersSortBy
    {
        NameAsc,
        NameDesc,
        CreateDateDesc
    }

    public static class BeersSortByExtension
    {
        public static BeersSortBy[] SortBys =
            Enum.GetValues(typeof(BeersSortBy)).Cast<BeersSortBy>().ToArray();

        public static string GetName(this BeersSortBy beersSortBy)
        {
            switch (beersSortBy)
            {
                case BeersSortBy.NameAsc: return "Name A to Z";
                case BeersSortBy.NameDesc: return "Name Z to A";
                case BeersSortBy.CreateDateDesc: return "Newest Arrivals";
                default: return beersSortBy.ToString();
            }
        }
    }
}