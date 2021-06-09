using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech.FruitSubspieces
{
    class ErdiSourCherry: SubspieceDecorator
    {
        public ErdiSourCherry(Fruit fruit)
       : base(fruit)
        {
            Cost = fruit.Cost + 100;
            HarvestingPlace = fruit.HarvestingPlace + "and it's harvested from the second tree row.";
        }

        public override int Cost
        {
            get => base.Cost;
            set => base.Cost = value + cost;
        }

        public override string HarvestingPlace
        {
            get => base.HarvestingPlace;
            set => base.HarvestingPlace = value + harvestingPlace;
        }

        public override string ToString()
        {
            return "ErdiSourCherry";
        }
    }
}
