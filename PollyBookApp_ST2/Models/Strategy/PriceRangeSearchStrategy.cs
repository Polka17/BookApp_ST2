using PollyBookApp_ST2.Models.ReadingItems;

namespace PollyBookApp_ST2.Models.Strategy
{
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
