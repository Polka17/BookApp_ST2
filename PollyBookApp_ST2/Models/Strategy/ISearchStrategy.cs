using PollyBookApp_ST2.Models.ReadingItems;

namespace PollyBookApp_ST2.Models.Strategy
{
    // The next pattern is Strategy. Initially I was thinking about sorting or filtering one, but we did it during the labs.
    // And additionally I have separate logic for filtering object by their type, so it was not suitable.
    // Therefore, here we come wtih the Search strategy.
    public interface ISearchStrategy
    {

        // We have a method that gets all the items and certain criteria as paramethers
        // The concrete startegy itself is implemented in the descendants.
        IEnumerable<ReadingItem> Search(IEnumerable<ReadingItem> items, string query);
    }
}
