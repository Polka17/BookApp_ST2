namespace PollyBookApp_ST2.Models.Strategy
{
    public class SeniorDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price * 0.85m; 
    }
}
