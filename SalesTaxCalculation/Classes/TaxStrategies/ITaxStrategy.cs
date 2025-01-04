namespace SalesTaxCalculation
{
    public interface ITaxStrategy
    {
        float CalculateTax(float basePrice);
    }
}
