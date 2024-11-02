using PollyBookApp_ST2.Models.Enums;

namespace PollyBookApp_ST2.Models.ReadingItems
{
    public class Book: ReadingItem
    {
        public string Author { get; set; }
        public string ISBN { get; set; }
        public Genre Genre { get; set; }
    }
}
