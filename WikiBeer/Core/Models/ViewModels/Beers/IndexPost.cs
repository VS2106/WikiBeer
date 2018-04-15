namespace WikiBeer.Core.Models.ViewModels.Beers
{
    public class IndexPost
    {
        public int CurrentPageNumber { get; set; }
        public int Style { get; set; }
        public BeersOrderBy OrderBy { get; set; }
        public bool IsSortAsc { get; set; }
        public string SearchName { get; set; }
    }
}