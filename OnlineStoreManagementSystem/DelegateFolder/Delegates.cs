using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManagementSystem
{
    public delegate List<EnumColor> MakeEnumColorTableDelegate();

    public class Delegates
    {

        public MakeEnumColorTableDelegate makeEnumColorTableDelegate;

        public Delegates()
        {
            makeEnumColorTableDelegate = MakeEnumColorTable;
        }

        public List<EnumColor> MakeEnumColorTable()
        {
            List<EnumColor> enumcolors = new List<EnumColor>();

            do
            {
                Console.WriteLine("");
            } while (true);

            return enumcolors;
        }
    }
}
