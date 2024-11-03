using PollyBookApp_ST2.Models.ReadingItems;

namespace PollyBookApp_ST2.Models.Strategy
{
    // In this descendant we use the reading items as the collection of object we would be searching in.
    // And the searching criteria will be the title (it will contain a key word that the user will input through the UI)
    public class TitleSearchStrategy: ISearchStrategy
    {
        public IEnumerable<ReadingItem> Search(IEnumerable<ReadingItem> items, string query)
        {
            return items.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
        }
    }
}
