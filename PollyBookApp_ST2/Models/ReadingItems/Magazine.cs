using PollyBookApp_ST2.Models.Enums;

namespace PollyBookApp_ST2.Models.ReadingItems
{
    public class Magazine: ReadingItem
    {
        public string Publisher { get; set; }
        public Domain Domain { get; set; }
    }
}
