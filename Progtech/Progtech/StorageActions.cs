using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech
{
    public class StorageActions : ISubject
    {
        public static Storage storage;
        public StorageActions()
        {
            storage = Storage.Instance;
        }

        public void fillStorageWithFruits()
        {
            for (int i = 0; i < 50; i++)
            {
                fillUpStorage("barack", "");
                fillUpStorage("cseresznye", "");
                fillUpStorage("meggy", "");
                fillUpStorage("barack", "bergeron");
                fillUpStorage("cseresznye", "linda");
                fillUpStorage("meggy", "erdi");
            }
        }

        public void selectMode()
        {

            Console.WriteLine("Type 1 if you want to deliver fruit to the storage or type 2 if you want to buy fruit! To list sellable fruits type 4 or to modify fruit properties pres 4!");
            string userInput=Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    addFruitToStorage();
                    break;
                case "2":
                    buyFruitFromStorage();
                    break;
                case "3":
                    modifyFruitProperties();
                    break;
                case "4":
                    Console.WriteLine(storage.getSellableFruits());
                    break;
                default:
                    break;
            }
        }

        public void addFruitToStorage()
        {
            Console.WriteLine("Please select the fruit you want to deliver: (1=Peach, 2=Cherry, 3=SourCherry, 4=BergeronPeach, 5=ErdiSourCherry, 6=LindaCherry");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    storage.addFruit(FruitFactory.makeFruit("barack", ""));
                    Console.WriteLine("You have succesfully delivered the chosen fruit!");
                    break;
                case "2":
                    storage.addFruit(FruitFactory.makeFruit("cseresznye", ""));
                    Console.WriteLine("You have succesfully delivered the chosen fruit!");
                    break;
                case "3":
                    storage.addFruit(FruitFactory.makeFruit("meggy", ""));
                    Console.WriteLine("You have succesfully delivered the chosen fruit!");
                    break;
                case "4":
                    storage.addFruit(FruitFactory.makeFruit("barack", "bergeron"));
                    Console.WriteLine("You have succesfully delivered the chosen fruit!");
                    break;
                case "5":
                    storage.addFruit(FruitFactory.makeFruit("meggy", "erdi"));
                    Console.WriteLine("You have succesfully delivered the chosen fruit!");
                    break;
                case "6":
                    storage.addFruit(FruitFactory.makeFruit("cseresznye", "linda"));
                    Console.WriteLine("You have succesfully delivered the chosen fruit!");
                    break;
                default:
                    break;
            }
        }

        public void buyFruitFromStorage()
        {
            Console.WriteLine("Please select the fruit you want to buy: (1=Peach, 2=Cherry, 3=SourCherry, 4=BergeronPeach, 5=ErdiSourCherry, 6=LindaCherry");
            string userInput = Console.ReadLine();
            double discount;
            double price;
            switch (userInput)
            {
                case "1":
                    removeFruitFromStorage(storage.getFruitByType("peach"));
                    discount = storage.getDiscounts();
                    price = discount * storage.getFruitByType("peach").Cost;

                    Console.WriteLine("You have succesfully purchased 1kg peach for {0} FT!", price);
                    break;
                case "2":
                    removeFruitFromStorage(storage.getFruitByType("cherry"));
                     discount = storage.getDiscounts();
                     price = discount * storage.getFruitByType("cherry").Cost;
                    Console.WriteLine("You have succesfully purchased 1kg cherry for {0} FT!", price);
                    break;
                case "3":
                    discount = storage.getDiscounts();
                    price = discount * storage.getFruitByType("sourcherry").Cost;
                    removeFruitFromStorage(storage.getFruitByType("sourcherry"));
                   
                    Console.WriteLine("You have succesfully purchased 1kg sourcherry for {0} FT!", price);
                    break;
                case "4":
                    removeFruitFromStorage(storage.getFruitByType("bergeronpeach"));
                     discount = storage.getDiscounts();
                     price = discount * storage.getFruitByType("bergeronpeach").Cost;
                    Console.WriteLine("You have succesfully purchased 1kg bergeron peach for {0} FT!", price);
                    break;
                case "5":
                    removeFruitFromStorage(storage.getFruitByType("erdisourcherry"));
                    discount = storage.getDiscounts();
                    price = discount * storage.getFruitByType("erdisourcherry").Cost;
                    Console.WriteLine("You have succesfully purchased 1kg erdi sourcherry for {0} FT!", price);
                    break;
                case "6":
                    removeFruitFromStorage(storage.getFruitByType("lindacherry"));
                    discount = storage.getDiscounts();
                    price = discount * storage.getFruitByType("lindacherry").Cost;
                    Console.WriteLine("You have succesfully purchased 1kg linda cherry for {0} FT!", price);
                    break;
                default:
                    break;
            }
        }

        public void modifyFruitProperties()
        {
            Console.WriteLine("Please write the name of the fruit: ");
            string fruitname = Console.ReadLine();
            Console.WriteLine("The new cost: ");
            int newCost = int.Parse(Console.ReadLine());
            Console.WriteLine("The new harvesting place: ");
            string harvestingPlace = Console.ReadLine();
            setProperties(fruitname, newCost, harvestingPlace);

        }


        public void removeFruitFromStorage(Fruit fruit)
        {
            storage.deleteFruit(fruit);
        }

        public void fillUpStorage(string fruit, string subspiece)
        {
            
            storage.fillStorageWithFruits(FruitFactory.makeFruit(fruit,subspiece));
        }

        public void setProperties(string fruit, int cost, string harvestingPlace)
        {
            Fruit f = storage.getFruitByType(fruit);
            Console.WriteLine("Old cost was:{0}, old harvesting place: {1}", f.Cost, f.HarvestingPlace);
            notifyObserver(f, cost, harvestingPlace);
            Console.WriteLine("New cost: {0}, new harvesting place: {1}",f.Cost,f.HarvestingPlace);
        }
        public void notifyObserver(Fruit fruit, int cost, string harvestingPlace)
        {
            
            foreach (var f in storage.SellableFruits)
            {
                if (f.GetType()==fruit.GetType())
                {
                    fruit.updateProperties(cost, harvestingPlace);
                }
            }
        }
    }
}
