namespace PollyBookApp_ST2.Models.ReadingItems
{
    public class ReadingItemFactory
    {
        // This is the  central part of the Factory Design Pattern - the Factory class.
        // Here based on a paramether that we get, during the creation process (from the Create form) of the object, we instance a particular reading item.
        // After making a comparison the specific object is created
        public static ReadingItem CreateReadingMaterial(string type)
        {
            return type.ToLower() switch
            {
                "book" => new Book(),
                "magazine" => new Magazine(),
                "comics" => new Comics(),
                _ => throw new ArgumentException("Invalid type")
            };
        }
    }
}
