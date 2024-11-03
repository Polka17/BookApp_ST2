using PollyBookApp_ST2.Models.Users;

namespace PollyBookApp_ST2.Models.ReadingItems
{
    // Here is the primary class (parent) for the Factory hierarchy.
    // I decided to use an abstract class instead of an interface, since I wanted to implement characteristics rather than behavior.
    // The descendants (the different types of object instanced by the factory) are the other classes here in the ReadingItems folder.
    public abstract class ReadingItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string PicturePath { get; set; }
        public string Description { get; set; }

    }
}
