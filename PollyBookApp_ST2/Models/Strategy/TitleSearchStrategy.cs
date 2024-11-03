using PollyBookApp_ST2.Models.ReadingItems;

namespace PollyBookApp_ST2.Models.Strategy
{
    public class TitleSearchStrategy: ISearchStrategy
    {
        public IEnumerable<ReadingItem> Search(IEnumerable<ReadingItem> items, string query)
        {
            return items.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
        }
    }
}
