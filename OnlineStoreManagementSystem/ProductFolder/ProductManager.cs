using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ToolBox;
using static ToolBox.Delegates;

namespace OnlineStoreManagementSystem
{
    public class ProductManager
    {
        #region Field

        private List<Product> _products = new List<Product>();

        #endregion

        #region Constructors

        public ProductManager() { }

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
        /// <exception cref="ElementNotRegisteredException"></exception>
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

        public void ShowAllProducts()
        {

            foreach (Product product in Products)
            {
                Console.WriteLine($"[{Products.IndexOf(product) + 1}]");

                if (product is Clothes clothes) clothes.ShowContents();
                if (product is Food food) food.ShowContents();
                if (product is PersonalCare personalCare) personalCare.ShowContents();

                Tool.AddLine();
            }
        }

        /// <summary>
        /// Add a product to the list « products ». Products will be distinguished by ID.
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Add(Product product)
        {
            // Verify if the product ID already exists in the list
            if(Products.Any(p => p.ProductId == product.ProductId))
            {
                throw new ElementAlreadyRegisteredException();
                //------------ AFTER EXECUTING THE EXEPTION, WHAT HAPPENS?? ---------
            }

            Products.Add(product);
            Console.WriteLine($"Product was successfully added");
            product.ShowContents();
        }

        /// <summary>
        /// Remove a product from the list « products ». 
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Product product)
        {
            // Verify if the ID does not existe in the list
            if (!(Products.Any(p => p.ProductId == product.ProductId)))
            {
                throw new ElementNotRegisteredException();
            }

            Products.RemoveAll(p => p.ProductId == product.ProductId);
            Console.WriteLine($"Product [{product.ProductId}] was successfully removed");
        }

        /// <summary>
        /// Remove a product from the list « products ».
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Guid id)
        {
            // Verify if the ID does not existe in the list
            if (!(Products.Any(p => p.ProductId == id)))
            {
                throw new ElementNotRegisteredException();
            }

            Products.Remove(this[id]);
            Console.WriteLine($"Product [{id}] was successfully removed");
        }

        /// <summary>
        /// Return the number of elements in the list « products »
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            if (Products is null) return 0;
            return Products.Count();
        }
        #endregion

        #region Product factory

        public Product AddProductStep1()
        {
            MessageDelegate message = () =>
            {
                Console.WriteLine("Choose product type by a number");
                Console.WriteLine("1 : Clothes");
                Console.WriteLine("2 : Food");
                Console.WriteLine("3 : Personal care");
            };

            Product? product = null;

            Tool.TryGetIntLimitedRange(message, 1, 3, out int result);
            switch (result)
            {
                case 1:
                    product = AddProductStep2<Clothes>();
                    break;
                case 2:
                    product = AddProductStep2<Food>();
                    break;
                case 3:
                    product = AddProductStep2<PersonalCare>();
                    break;
            }
            return product;
        }

        public T AddProductStep2<T>() where T : Product, new()
        {
            // Create new T instance
            T product = new T();
            
            // Assign common fields
            //product.ProductId = Guid.NewGuid();
            product.Name = AskName();
            product.Price = AskPrice();

            // Assign the rest of the field depending on the type
            if (product is Clothes clothes)
            {
                clothes.ClothesCategory = ClothesManager.AskClothesCategory();
                clothes.Colors = ColorManager.MakeColorTable();
            }

            else if (product is Food food)
            {
                food.Allergies = AllergyManager.MakeAllergyTable();
            }

            else if (product is PersonalCare personalCare)
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
            MessageDelegate message = () => 
            {
                Console.WriteLine("How much is it?");
            };

            double price = Tool.GetDouble(message);
            return price;
        }

        #endregion

        #endregion
    }
}
