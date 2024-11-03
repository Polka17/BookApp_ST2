using PollyBookApp_ST2.Models.ReadingItems;

namespace PollyBookApp_ST2.Models.Strategy
{
    public interface ISearchStrategy
    {
        IEnumerable<ReadingItem> Search(IEnumerable<ReadingItem> items, string query);
    }
}
