using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech.Fruits
{
    public class Cherry : Fruit
    {
        public Cherry()
        {
            this.Cost = 1000;
            this.HarvestingPlace = "Szihalom";
        }

        public override int Cost { 
            get => cost;
            set => cost=value; 
        }
        public override string HarvestingPlace { 
            get => harvestingPlace;
            set => harvestingPlace = value; }
        public override string ToString()
        {
            return "Cherry";
        }

    }
}
