namespace PollyBookApp_ST2.Models.Strategy
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal price);
    }
}
