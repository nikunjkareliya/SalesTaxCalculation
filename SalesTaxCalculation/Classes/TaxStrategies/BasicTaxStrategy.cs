using System;

namespace SalesTaxCalculation
{
    public class BasicTaxStrategy : ITaxStrategy
    {
        public float CalculateTax(float basePrice)
        {
            float regularTax = basePrice * 0.1f; // 10% regular tax
            regularTax = (float)Math.Ceiling(regularTax * 20) / 20; // Round up to nearest 0.05
            return regularTax;
        }
    }
}
