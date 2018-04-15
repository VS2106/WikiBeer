namespace WikiBeer.Core.Models.ViewModels.Beers
{
    public class IndexPost
    {
        public int CurrentPageNumber { get; set; }
        public int Style { get; set; }
        public BeersSortBy SortBy { get; set; }
        public string SearchName { get; set; }
    }
}