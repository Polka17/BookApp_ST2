using PollyBookApp_ST2.Models.Enums;

namespace PollyBookApp_ST2.Models.ReadingItems
{
    // Here we have another implementation of the parent class and extending the functionality.
    public class Magazine: ReadingItem
    {
        public string Publisher { get; set; }
        public Domain Domain { get; set; }
    }
}
