using PollyBookApp_ST2.Models.ReadingItems;

namespace PollyBookApp_ST2.Models.Strategy
{
    // In this descendant, again we use the reading items as the collection of object we would be searching in.
    // We still have the query to meet the overriding requirements and be able to use this functionallity as well,
    //  but we also have additional values that are the price range of the items we would like to show.
    public class PriceRangeSearchStrategy: ISearchStrategy
    {
        private readonly decimal _minPrice;
        private readonly decimal _maxPrice;

        public PriceRangeSearchStrategy(decimal minPrice, decimal maxPrice)
        {
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        public IEnumerable<ReadingItem> Search(IEnumerable<ReadingItem> items, string query)
        {
            return items.Where(i => i.Price >= _minPrice && i.Price <= _maxPrice);
        }
    }
}
