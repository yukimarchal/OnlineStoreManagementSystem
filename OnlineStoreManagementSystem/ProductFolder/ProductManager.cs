using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using ToolBox.PersonalCareTools;
using static ToolBox.Delegates;

namespace OnlineStoreManagementSystem
{
    public class ProductManager
    {
        #region Field

        private List<Product> _products = new List<Product>();

        #endregion

        #region Constructors

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
                // Verify if the id is not registered
                if(!(Products.Any(p => p.ProductId == id)))
                {
                    throw new ElementNotRegisteredException();
                }
                
                // Find the element by the id and return
                Product result = null;

                foreach (Product product in Products)
                {
                    if (id == product.ProductId) result = product;
                }

                return result;
            }
        }
        #endregion

        #region Methods

        #region List managers

        /// <summary>
        /// Add a product to the list « products ». Products wills be distinguished by ID.
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Add(Product product)
        {
            // Verify if the product ID already exists in the list
            if(Products.Any(p => p.ProductId == product.ProductId))
            {
                throw new ElementAlreadyRegisteredException();
                !//------------ AFTER EXECUTING THE EXEPTION, WHAT HAPPENS?? ---------
            }

            Products.Add(product);
        }

        /// <summary>
        /// Remove a product from the list « products ». 
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Product product)
        {
            // Verify if the product ID does not existe in the list
            if (!(Products.Any(p => p.ProductId == product.ProductId)))
            {
                throw new ElementNotRegisteredException();
            }

            Products.RemoveAll(p => p.ProductId == product.ProductId);
        }

        /// <summary>
        /// Remove a product from the list « products ».
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Guid id)
        {
            // Verify if the product ID does not existe in the list
            if (!(Products.Any(p => p.ProductId == id)))
            {
                throw new ElementNotRegisteredException();
            }

            Products.Remove(this[id]);
        }

        /// <summary>
        /// Return the number of elements in the list « products »
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Products.Count;
        }
        #endregion

        #region Product factory

        public T AddProduct<T>() where T : Product, new()
        {
            // Create new T instance
            T product = new T();
            
            // Assign common fields
            product.ProductId = Guid.NewGuid();
            product.Name = AskName();
            product.Price = AskPrice();

            // Assign the rest of the field depending on the type
            if (product is Food food)
            {
                food.Allergies = AllergyManager.MakeAllergyTable();
            }

            if (product is Clothes clothes)
            {
                clothes.ClothesCategory = ClothesManager.AskClothesCategory();
                clothes.Colors = ColorManager.MakeColorTable();
            }

            if (product is PersonalCare personalCare)
            {
                personalCare.PersonalCareCategory = PersonalCareManager.AskPersonalCareCategory();
                personalCare.Colors = ColorManager.MakeColorTable();
                personalCare.Allergies = AllergyManager.MakeAllergyTable();
            }

            return product;
        }

        /// <summary>
        /// Ask for the name of the product
        /// </summary>
        /// <returns></returns>
        public string AskName()
        {
            Console.WriteLine("What is the name of the product?");
            string name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Ask for the price of the product
        /// </summary>
        /// <returns></returns>
        public double AskPrice()
        {
            MessageDelegate message = () => Console.WriteLine("How much is it?");
            Console.WriteLine("How much is it?");
            double price = Tool.GetDouble(message);
            return price;
        }

        #endregion

        #endregion
    }
}
