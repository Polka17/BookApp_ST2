using PollyBookApp_ST2.Models.Enums;

namespace PollyBookApp_ST2.Models.ReadingItems
{
    public class Comics: ReadingItem
    {
        public Style Style { get; set; }
        public Edition Edition { get; set; }
    }
}
