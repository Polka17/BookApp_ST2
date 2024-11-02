namespace PollyBookApp_ST2.Models.Strategy
{
    public class DiscountContext
    {
        private readonly IDiscountStrategy _discountStrategy;

        public DiscountContext(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public decimal GetFinalPrice(decimal price) => _discountStrategy.ApplyDiscount(price);
    }
}
