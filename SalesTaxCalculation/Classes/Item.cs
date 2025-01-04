using System.Collections.Generic;

namespace SalesTaxCalculation
{
    /// <summary>
    /// Kind of Context class as it holds current strategy reference
    /// Sets the strategy run-time
    /// </summary>
    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public bool IsImported { get; }
        public float BasePrice { get; }

        private ITaxStrategy _currentStrategy;
        
        public Item(string name, ItemType itemType, bool isImported, float basePrice, ITaxStrategy taxStrategy)
        {
            Name = name;
            Type = itemType;
            IsImported = isImported;
            BasePrice = basePrice;

            _currentStrategy = taxStrategy;
        }

        public float GetTax()
        {
            if (_currentStrategy == null)
            {
                return 0;
            }

            return _currentStrategy.CalculateTax(BasePrice);
        }

        public float GetPriceWithTax()
        {
            return BasePrice + GetTax();
        }

    }

}
