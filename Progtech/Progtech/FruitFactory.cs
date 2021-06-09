using Progtech.Fruits;
using Progtech.FruitSubspieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtech
{
    abstract class FruitFactory
    {
        static public Fruit makeFruit(string fruitName, string subspiece)
        {
            try
            {
                if (fruitName.ToUpper() == "BARACK")
                {
                    if (subspiece!="")
                    {
                        return makeFruitSubspiece(new Peach(), subspiece);
                    }
                    return new Peach();
                }
                else if (fruitName.ToUpper() == "MEGGY")
                {
                    if (subspiece != "")
                    {
                        return makeFruitSubspiece(new SourCherry(), subspiece);
                    }
                    return new SourCherry();
                }
                else if (fruitName.ToUpper() == "CSERESZNYE")
                {
                    if (subspiece != "")
                    {
                        return makeFruitSubspiece(new Cherry(), subspiece);
                    }
                    return new Cherry();
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception("Invalid parameter value!");
            }
        }

        static public Fruit makeFruitSubspiece(Fruit fruit, string subspiece)
        {
            try
            {
                if (subspiece.ToUpper() == "BERGERON")
                {
                    return new BergeronPeach(fruit);
                }
                else if (subspiece.ToUpper() == "LINDA")
                {
                    return new LindaCherry(fruit);
                }
                else if (subspiece.ToUpper() == "ERDI")
                {
                    return new ErdiSourCherry(fruit);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
               
                throw new Exception("Invalid parameter value!");
             
            }
           
        }
    }
}
