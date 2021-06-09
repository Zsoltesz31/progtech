using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech
{
    class SubspieceDecorator : Fruit
    {
        protected Fruit fruitSubspiece;
        public SubspieceDecorator(Fruit fruit)
        {
            this.fruitSubspiece = fruit;
        }

        public override int Cost {
            get => fruitSubspiece.Cost;
            set => fruitSubspiece.Cost=value; 
        }

        public override string HarvestingPlace {
            get => fruitSubspiece.HarvestingPlace;
            set => fruitSubspiece.HarvestingPlace=value; }
        }
}
