using System;

namespace SalesTaxCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Receipt receipt = new Receipt();

            InputReader inputReader = new InputReader();

            int itemCount = inputReader.ReadItemCount();

            for (int i = 0; i < itemCount; i++)
            {
                string name = inputReader.ReadItemName(i + 1);
                ItemType type = inputReader.ReadItemType();
                bool isImported = inputReader.ReadIsImported();
                float basePrice = inputReader.ReadBasePrice();

                ITaxStrategy strategy = TaxStrategyFactory.Create(type, isImported);
                Item item = ItemFactory.CreateItem(name, type, isImported, basePrice, strategy);
                receipt.Add(item);
                Console.WriteLine();
            }


            Console.WriteLine("----------------------- RECEIPT -----------------------");
            Console.WriteLine();

            Printer printer = new Printer();
            printer.Print(receipt);

            Console.WriteLine();
            Console.WriteLine("----------------------- END ---------------------------");
        }
    }
}
