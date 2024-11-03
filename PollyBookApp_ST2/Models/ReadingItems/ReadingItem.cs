using PollyBookApp_ST2.Models.Users;

namespace PollyBookApp_ST2.Models.ReadingItems
{
    public abstract class ReadingItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PicturePath { get; set; }
        public string Description { get; set; }

    }
}
