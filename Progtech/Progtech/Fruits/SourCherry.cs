using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech.Fruits
{
    class SourCherry : Fruit
    {
        public SourCherry()
        {
            this.Cost = 900;
            this.HarvestingPlace = "Pityor";
        }
        public override int Cost
        {
            get => cost;
            set => cost = value;
        }
        public override string HarvestingPlace
        {
            get => harvestingPlace;
            set => harvestingPlace = value;
        }
        public override string ToString()
        {
            return "SourCherry";
        }
    }
}
