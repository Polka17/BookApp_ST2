namespace PollyBookApp_ST2.Models.Strategy
{
    public class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price;
    }
}
