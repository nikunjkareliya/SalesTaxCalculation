using System.Collections.Generic;

namespace SalesTaxCalculation
{
    /// <summary>
    /// Composite Tax Strategy
    /// I had to use this bcoz in some edge cases we have to calculate multiple types of tax on base price
    /// </summary>
    public class CompositeTaxStrategy : ITaxStrategy
    {
        private List<ITaxStrategy> _strategies;

        public CompositeTaxStrategy(List<ITaxStrategy> strategies)
        {
            _strategies = strategies;
        }

        public float CalculateTax(float basePrice)
        {
            float totalTax = 0;
            foreach (var strategy in _strategies)
            {
                totalTax += strategy.CalculateTax(basePrice);
            }

            return totalTax;
        }
    }

}
