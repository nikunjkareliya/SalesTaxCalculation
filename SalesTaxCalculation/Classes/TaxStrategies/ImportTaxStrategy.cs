using System;

namespace SalesTaxCalculation
{
    public class ImportTaxStrategy : ITaxStrategy
    {
        public float CalculateTax(float basePrice)
        {
            float importedTax = basePrice * 0.05f; // 5% import duty
            importedTax = (float)Math.Ceiling(importedTax * 20) / 20; // Round up to nearest 0.05
            return importedTax;
        }
    }
}
