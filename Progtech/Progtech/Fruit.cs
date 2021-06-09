using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech
{
   
   public abstract class Fruit : IStorageObserver
    {
       
        protected string harvestingPlace;
        protected int cost;

        public abstract string HarvestingPlace 
        {   get;
            set;
        }
       
        public abstract int Cost 
        { get;
          set; 
        }

       public void updateProperties(int cost, string harvestingPlace)
       {
            Cost = cost;
            HarvestingPlace = harvestingPlace;
       }
    }
}
