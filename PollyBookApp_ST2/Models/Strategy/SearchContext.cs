using PollyBookApp_ST2.Models.ReadingItems;

namespace PollyBookApp_ST2.Models.Strategy
{
    public class SearchContext
    {
        private ISearchStrategy _searchStrategy;

        public void SetSearchStrategy(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }

        public IEnumerable<ReadingItem> ExecuteSearch(IEnumerable<ReadingItem> items, string query)
        {
            return _searchStrategy.Search(items, query);
        }
    }
}
