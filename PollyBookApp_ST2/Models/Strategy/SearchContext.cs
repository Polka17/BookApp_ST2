using PollyBookApp_ST2.Models.ReadingItems;

namespace PollyBookApp_ST2.Models.Strategy
{
    // We have this context in order to provide access to the different types of strategies and provide some type of control to execute
    // Like the Observer - the Strategy pattern is again specified and executed in the controller
    public class SearchContext
    {
        private ISearchStrategy _searchStrategy;

        // We have a methods that sets the strategy based on the types of strategy the user has chosen
        public void SetSearchStrategy(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }

        // Here we execute the said strategy as we give it a collection of items to be used and a type of query for the searching criteria
        public IEnumerable<ReadingItem> ExecuteSearch(IEnumerable<ReadingItem> items, string query)
        {
            return _searchStrategy.Search(items, query);
        }
    }
}
