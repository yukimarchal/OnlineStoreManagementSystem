using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManagementSystem
{
    public class ProductManager
    {
        #region Field

        private List<Product> _products = new List<Product>();

        #endregion

        #region Constructor

        public ProductManager(List<Product> products)
        {
            Products = products;
        }

        #endregion

        #region Properties

        public List<Product> Products
		{
			get { return _products; }
			set { _products = value; }
		}

        #endregion

        #region Indexer

        /// <summary>
        /// Indexer to find a product by the ProductId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Product? this[Guid id]
        {
            get
            {
                if(!(Products.Any(p => p.ProductId == id)))
                {
                    throw new KeyNotFoundException();
                }

                Product result = null;

                foreach (Product product in Products)
                {
                    if (id == product.ProductId) result = product;
                }

                return result;
            }
        }

        #endregion
    }
}
