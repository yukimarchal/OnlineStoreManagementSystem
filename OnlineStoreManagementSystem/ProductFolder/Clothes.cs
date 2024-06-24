using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreManagementSystem.ProductFolder;

namespace OnlineStoreManagementSystem
{
    public class Clothes : Product, IColorManager
    {
        #region Field

        private Category _category;
        private List<Color> _colors = new List<Color>();

        #endregion

        #region Constuctors

        public Clothes(string name, double price, Category category, ) : base(name, price)
        {
            
        }


        #endregion

        #region Properties

        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public List<Color> Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }

        #endregion
    }
}
