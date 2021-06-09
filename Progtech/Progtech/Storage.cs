using Progtech.Fruits;
using Progtech.FruitSubspieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech
{
    public class Storage
    {
        private Storage() {
            SellableFruits = new List<Fruit>();
        }
        private static Storage instance = null;
        public static Storage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Storage();
                }
                return instance;
            }
        }


        private string storageLocation;
        private List<Fruit> sellableFruits;
        private static int CAPACITY = 500;

        public string StorageLocation { get => storageLocation; set => storageLocation = value; }
        public List<Fruit> SellableFruits { get => sellableFruits; set => sellableFruits = value; }

        public double getDiscounts()
        {
            double discount = 1;
            try
            {
                if (SellableFruits.Count >= 50)
                {
                    Console.WriteLine("You've got a 20% discount!");
                    return discount = 0.8;
                }
                else if(SellableFruits.Count >= 100)
                {
                    Console.WriteLine("You've got a 40% discount!");
                    return discount = 0.6;
                }
                else if(SellableFruits.Count >= 200)
                {
                    Console.WriteLine("You've got a 60% discount!");
                    return discount = 0.4;
                }
                return discount;
            }
            catch (Exception)
            {

                throw new Exception("We have no more fruits left to sell!");
            }
        }

        public void addFruit(Fruit fruit)
        {
            if (SellableFruits.Count<CAPACITY)
            {
                SellableFruits.Add(fruit);
            }
            else
            {
                Console.WriteLine("Storage is full!");
            }
        }

        public void deleteFruit(Fruit fruit)
        {
            if (SellableFruits.Contains(fruit))
            {
                SellableFruits.Remove(fruit);
            }
            else
            {
                Console.WriteLine("There is no more fruit from that spiece!");
            }
        }

        public string getSellableFruits()
        {
            int sourCherryQuantity=0;
            int cherryQuantity=0;
            int peachQuantity=0;
            int erdiSourCherryQuantity = 0;
            int lindaCherryQuantity = 0;
            int bergeronPeachQuantity = 0;
            string sellableFruitListing = "";
            if (SellableFruits.Count>0)
            {
                for (int i = 0; i < SellableFruits.Count; i++)
                {
                    if (SellableFruits[i] is SourCherry)
                    {
                        sourCherryQuantity++;
                    }
                    else if (SellableFruits[i] is Cherry)
                    {
                        cherryQuantity++;
                    }
                    else if (SellableFruits[i] is Peach)
                    {
                        peachQuantity++;
                    }
                    else if (SellableFruits[i] is ErdiSourCherry)
                    {
                        erdiSourCherryQuantity++;
                    }
                    else if (SellableFruits[i] is LindaCherry)
                    {
                        lindaCherryQuantity++;
                    }
                    else if (SellableFruits[i] is BergeronPeach)
                    {
                        bergeronPeachQuantity++;
                    }

                }
                return sellableFruitListing = "Cherry: " + sourCherryQuantity+ ", SourCherry: " + cherryQuantity + ", Peach: "+ peachQuantity + ", ErdiSourCherry: "+ erdiSourCherryQuantity + ", LindaCherry: "+ lindaCherryQuantity + ", BergeronPeach: "+ bergeronPeachQuantity + ".";
            }
            else
            {
                return sellableFruitListing = "We ran out of fruits";

            }
        }
        public void fillStorageWithFruits(Fruit fruit)
        {
           
                if (fruit is Peach)
                    sellableFruits.Add(new Peach());
                if (fruit is SourCherry)
                    sellableFruits.Add(new SourCherry());
                if (fruit is Cherry)
                    sellableFruits.Add(new Cherry());
                if (fruit is BergeronPeach)
                    sellableFruits.Add(new BergeronPeach(fruit));
                if (fruit is ErdiSourCherry)
                    sellableFruits.Add(new ErdiSourCherry(fruit));
                if (fruit is LindaCherry)
                    sellableFruits.Add(new LindaCherry(fruit));
           
        }

        public Fruit getFruitByType(string fruit)
        {
            Fruit selectedFruit;
            try
            {
                
                selectedFruit = SellableFruits.Find(f => f.ToString().ToLower()==fruit.ToLower());
            }
            catch (Exception)
            {

                throw new Exception("We couldn't find any fruit that matches your wish!");
            }
            return selectedFruit;
        }
       
    }
}
