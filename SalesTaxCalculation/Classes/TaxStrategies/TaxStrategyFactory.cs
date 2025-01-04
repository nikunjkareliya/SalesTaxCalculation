using System.Collections.Generic;

namespace SalesTaxCalculation
{
    public static class TaxStrategyFactory
    {
        public static ITaxStrategy Create(ItemType itemType, bool isImported)
        {
            List<ITaxStrategy> strategies = new List<ITaxStrategy>();

            if (itemType == ItemType.RegularItem)
            {
                ITaxStrategy basic = new BasicTaxStrategy();
                strategies.Add(basic);
            }

            if (isImported)
            {
                ITaxStrategy import = new ImportTaxStrategy();
                strategies.Add(import);
            }

            ITaxStrategy composite = new CompositeTaxStrategy(strategies);
            return composite;
        }
    }
}
