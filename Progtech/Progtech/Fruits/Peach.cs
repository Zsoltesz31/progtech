using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech.Fruits
{
    public class Peach : Fruit
    {
        public Peach()
        {
            this.Cost = 1200;
            this.HarvestingPlace = "Csókahegy";
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
            return "Peach";
        }
    }
}
