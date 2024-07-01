using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public class Clothes : Product
    {
        #region Field

        private EnumClothes _clothesCategory;
        private List<EnumColor> _colors = new List<EnumColor>();

        #endregion

        #region Constuctors

        public Clothes()
        {
            ProductId = Guid.NewGuid();
        }

        public Clothes(string name, double price, EnumClothes clothesCategory, params EnumColor[] colors) : base(name, price)
        {
            ProductId = Guid.NewGuid();
            ClothesCategory = clothesCategory;

            foreach (EnumColor color in colors)
            {
                Colors.Add(color);
            }
        }

        #endregion

        #region Properties

        public EnumClothes ClothesCategory
        {
            get { return _clothesCategory; }
            set { _clothesCategory = value; }
        }
        public List<EnumColor> Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }

        public override void ShowContents()
        {
            // Make a string with all the registered colors
            string colorList = "";
            foreach (EnumColor color in Colors)
            {
                colorList += color.ToString();
                colorList += ", ";
            }

            // Show all the contents of this object
            Console.WriteLine($"ID : {ProductId}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Price : {Price}");
            Console.WriteLine($"Clothes category : {ClothesCategory}");
            Console.WriteLine($"Colors : {colorList}");
        }

        #endregion
    }
}
