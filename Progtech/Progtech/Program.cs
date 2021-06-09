using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageActions sa = new StorageActions();
            sa.fillStorageWithFruits();
            sa.selectMode();
            Console.ReadKey();
        }
    }
}
