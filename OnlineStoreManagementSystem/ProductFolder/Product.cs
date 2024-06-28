using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public abstract class Product
    {
        #region Field

        private Guid _productId;
		private string _name;
		private double _price;

        #endregion

        #region Constructors

        protected Product()
        {
            ProductId = Guid.NewGuid();
        }

        public Product(string name, double price)
        {
            ProductId = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        #endregion

        #region Properties

        public Guid ProductId
		{
			get { return _productId; }
			set { _productId = value; }
		}
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        #endregion

        #region Methods

        public abstract void ShowContents();

        #endregion
    }
}
