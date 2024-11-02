namespace PollyBookApp_ST2.Models.Strategy
{
    public class StudentDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price * 0.8m;
    }
}
