using System;
using System.Collections.Generic;

namespace SalesTaxCalculation
{
    public class Printer
    {        
        public void Print(Receipt receipt)
        {
            List<Item> items = receipt.Items;

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Name} | Type: {items[i].Type} | Is imported? {items[i].IsImported} | Price with tax: {items[i].GetPriceWithTax()}");
            }

            Console.WriteLine();
            Console.WriteLine($"Tax to be paid: {receipt.GetTotalTaxToBePaid()}");
            Console.WriteLine($"Total: {receipt.GetTotalPriceToBePaid()}");
        }
    }
}
