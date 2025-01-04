using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesTaxCalculation.UnitTests
{
    [TestClass]
    public class SalesTaxCalculationTests
    {        
        [TestMethod]
        public void TestBookPrice()
        {
            ITaxStrategy strategy = TaxStrategyFactory.Create(ItemType.Book, isImported: false);
            Item item = ItemFactory.CreateItem("Item#1", ItemType.Book, isImported: false, 12.49f, strategy);
            float price = item.GetPriceWithTax();

            Assert.AreEqual(12.49f, price);
        }

        [TestMethod]
        public void TestImportedBookPrice()
        {
            ITaxStrategy strategy = TaxStrategyFactory.Create(ItemType.Book, isImported: true);
            Item item = ItemFactory.CreateItem("Item#2", ItemType.Book, isImported: true, 100.0f, strategy);
            float price = item.GetPriceWithTax();

            Assert.AreEqual(105.0f, price);
        }

        [TestMethod]
        public void TestRegularItemPrice()
        {
            ITaxStrategy strategy = TaxStrategyFactory.Create(ItemType.RegularItem, isImported: false);
            Item item = ItemFactory.CreateItem("Item#3", ItemType.RegularItem, isImported: false, 14.99f, strategy);
            float price = item.GetPriceWithTax();

            Assert.AreEqual(16.49f, price);
        }

        [TestMethod]
        public void TestImportedRegularItemPrice()
        {
            ITaxStrategy strategy = TaxStrategyFactory.Create(ItemType.RegularItem, isImported: true);
            Item item = ItemFactory.CreateItem("Item#4", ItemType.RegularItem, isImported: true, 47.50f, strategy);
            float price = item.GetPriceWithTax();

            Assert.AreEqual(54.65f, price);
        }

        [TestMethod]
        public void TestOnlyTaxForBookAndImportedRegularItem()
        {
            ITaxStrategy strategy = TaxStrategyFactory.Create(ItemType.Book, isImported: false);
            Item item = ItemFactory.CreateItem("Item#1", ItemType.Book, isImported: false, 12.49f, strategy);
            float tax1 = item.GetTax();

            strategy = TaxStrategyFactory.Create(ItemType.RegularItem, isImported: true);
            item = ItemFactory.CreateItem("Item#4", ItemType.RegularItem, isImported: true, 47.50f, strategy);
            float tax2 = item.GetTax();

            float total = tax1 + tax2;

            Assert.AreEqual(7.15f, total);
        }

        [TestMethod]
        public void TestTotalPriceBookAndImportedRegularItem()
        {
            ITaxStrategy strategy = TaxStrategyFactory.Create(ItemType.Book, isImported: false);
            Item item = ItemFactory.CreateItem("Item#1", ItemType.Book, isImported: false, 12.49f, strategy);
            float price1 = item.GetPriceWithTax();

            strategy = TaxStrategyFactory.Create(ItemType.RegularItem, isImported: true);
            item = ItemFactory.CreateItem("Item#4", ItemType.RegularItem, isImported: true, 47.50f, strategy);
            float price2 = item.GetPriceWithTax();

            float total = price1 + price2;

            Assert.AreEqual(67.14f, total);
        }
    }
}
