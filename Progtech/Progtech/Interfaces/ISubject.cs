using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech
{
    interface ISubject
    {
        void fillUpStorage(string fruit, string subspiece);
        void removeFruitFromStorage(Fruit fruit);
        void notifyObserver(Fruit fruit, int cost, string harvestingPlace);
    }
}
