namespace PollyBookApp_ST2.Models.ReadingItems
{

    // I decided to use the factory method, because it seemed to meet my requirements, regarding the various object types instansing.
    // Moreover, I didn't want to overcomplicate the main structure of the app, so this pattern is simple,but effective.

    // This is the  central part of the Factory Design Pattern - the Factory class.
    public class ReadingItemFactory
    {
        // Here based on a paramether that we get, during the creation process (from the Create form) of the object, we instance a particular reading item.
        // After making a comparison the specific object is created.
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
