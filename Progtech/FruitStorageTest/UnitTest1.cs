using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Progtech;
using Progtech.Fruits;

namespace FruitStorageTest
{
    [TestClass]
    public class UnitTest1
    {
        StorageActions sa = new StorageActions();
        [TestMethod]
        public void addFruitTest()
        {
    
            Cherry testFruit = new Cherry();
            int storageSellableFruitCounter = StorageActions.storage.SellableFruits.Count;
            StorageActions.storage.addFruit(testFruit);
            int storageSellableFruitCounterAfter = StorageActions.storage.SellableFruits.Count;
            Assert.AreNotEqual(storageSellableFruitCounter, storageSellableFruitCounterAfter,"Addition failed!");

        }

        [TestMethod]
        public void deleteFruitTest()
        {

            Cherry testFruit = new Cherry();
            StorageActions.storage.addFruit(testFruit);
            int storageSellableFruitCounter = StorageActions.storage.SellableFruits.Count;
            StorageActions.storage.deleteFruit(testFruit);
            int storageSellableFruitCounterAfter = StorageActions.storage.SellableFruits.Count;
            Assert.AreNotEqual(storageSellableFruitCounter, storageSellableFruitCounterAfter, "Deletion failed!");
        }

        [TestMethod]

        public void getSellableFruitsTest()
        {
            Cherry testFruit1 = new Cherry();
            Peach testFruit2 = new Peach();

            StorageActions.storage.addFruit(testFruit1);
            StorageActions.storage.addFruit(testFruit2);
            string result = StorageActions.storage.getSellableFruits();
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void getDiscountsTest()
        {
            Cherry testFruit = new Cherry();
            int costBeforeDiscount = testFruit.Cost;
            for (int i = 0; i < 300; i++)
            {
                StorageActions.storage.addFruit(testFruit);
            }
            double discount = StorageActions.storage.getDiscounts();
            double costAfterDiscount = testFruit.Cost * discount;
            Assert.AreNotEqual(costBeforeDiscount, costAfterDiscount);
            
        }

        [TestMethod]

        public void getFruitByTypeTest()
        {
            StorageActions.storage.addFruit(new Cherry());
            Assert.IsNotNull(StorageActions.storage.getFruitByType("cherry"));
        }
    }
}
