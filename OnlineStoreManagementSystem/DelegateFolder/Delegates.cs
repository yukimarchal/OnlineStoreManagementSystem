using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManagementSystem
{
    public delegate List<Color> MakeColorTableDelegate();

    public class Delegates
    {

        public MakeColorTableDelegate makeColorTableDelegate;

        public Delegates()
        {
            makeColorTableDelegate = MakeColorTable;
        }

        public List<Color> MakeColorTable()
        {
            List<Color> colors = new List<Color>();

            do
            {
                Console.WriteLine("");
            } while (true);

            return colors;
        }
    }
}
