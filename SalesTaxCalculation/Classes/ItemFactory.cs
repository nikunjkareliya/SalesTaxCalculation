using System.Collections.Generic;

namespace SalesTaxCalculation
{
    /// <summary>
    /// We're using factory design pattern to generate items with different properties
    /// </summary>
    public static class ItemFactory
    {
        public static Item CreateItem(string name, ItemType type, bool isImported, float basePrice, ITaxStrategy strategy)
        {
            var item = new Item(name, type, isImported, basePrice, strategy);
            return item;
        }
    }
}
