using System;

namespace SalesTaxCalculation
{
    public class InputReader
    {
        public int ReadItemCount()
        {
            Console.Write("Enter the number of items: ");
            int itemCount;
            while (true)
            {
                try
                {
                    itemCount = int.Parse(Console.ReadLine());
                    if (itemCount > 0) 
                    {
                        break;
                    }
                    Console.Write("Invalid number. Please enter a positive integer: ");
                }
                catch (Exception)
                {
                    Console.Write("Invalid number. Please enter a positive integer: ");
                }
            }
            return itemCount;
        }

        public string ReadItemName(int itemNumber)
        {
            Console.WriteLine($"Enter details for item {itemNumber}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            return name;
        }

        public ItemType ReadItemType()
        {            
            Console.WriteLine("Select Item Type:");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Food");
            Console.WriteLine("3. Medicines");
            Console.WriteLine("4. RegularItem");

            int typeNumber;
            while (true)
            {
                try
                {
                    typeNumber = int.Parse(Console.ReadLine());
                    if (typeNumber >= 1 && typeNumber <= 4) break;
                    Console.WriteLine("Invalid choice. Please select a number between 1 and 4.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }

            ItemType itemType = (ItemType)(typeNumber - 1);
            return itemType;
        }

        public bool ReadIsImported()
        {            
            Console.Write("Is it imported? (y/n): ");
            string importedInput = Console.ReadLine().ToLower();
            bool isImported = (importedInput == "y") ? true : false;
            return isImported;
        }

        public float ReadBasePrice()
        {
            Console.Write("Base Price: ");
            float basePrice;
            while (true)
            {
                try
                {
                    basePrice = float.Parse(Console.ReadLine());
                    if (basePrice > 0) break;
                    Console.Write("Invalid price. Please enter a positive number: ");
                }
                catch (Exception)
                {
                    Console.Write("Invalid price. Please enter a positive number: ");
                }
            }
            return basePrice;
        }
    }
}
