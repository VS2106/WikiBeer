using System.Collections.Generic;

namespace WikiBeer.Core.Models.ViewModels.Beers
{
    public class IndexPost
    {
        public int CurrentPageNumber { get; set; }
        public int Style { get; set; }
        public BeersSortBy SortBy { get; set; }
        public string SearchName { get; set; }

        public virtual KeyValuePair<string, string>[] GetQuery()
        {
            var beersQuery = new List<KeyValuePair<string, string>>();
            if (Style != 0)
            {
                beersQuery.Add(new KeyValuePair<string, string>("styleId", Style.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(SearchName))
            {
                beersQuery.Add(new KeyValuePair<string, string>("name", SearchName.Trim()));
            }
            beersQuery.Add(new KeyValuePair<string, string>("p", CurrentPageNumber.ToString()));
            beersQuery.Add(new KeyValuePair<string, string>("order", SortBy.GetOrderQueryValue()));
            beersQuery.Add(new KeyValuePair<string, string>("sort", SortBy.GetSortQueryValue()));
            return beersQuery.ToArray();
        }
    }
}