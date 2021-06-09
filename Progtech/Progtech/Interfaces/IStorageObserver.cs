using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech
{
    interface IStorageObserver
    {
        void updateProperties(int cost, string harvestingPlace);
    }
}
