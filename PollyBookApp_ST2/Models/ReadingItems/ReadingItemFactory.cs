namespace PollyBookApp_ST2.Models.ReadingItems
{
    public class ReadingItemFactory
    {
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
