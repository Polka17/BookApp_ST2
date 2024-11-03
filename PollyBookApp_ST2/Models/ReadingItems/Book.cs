using PollyBookApp_ST2.Models.Enums;

namespace PollyBookApp_ST2.Models.ReadingItems
{
    // A ReadingItem decendant that extends the functionality with several properties.
    // Since I wanted to have fields with predefined values I used the enum type for some of them (they are in the Enums folder on Models)
    public class Book: ReadingItem
    {
        public string Author { get; set; }
        public string ISBN { get; set; }
        public Genre Genre { get; set; }
    }
}
