using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using static ToolBox.Delegates;

namespace OnlineStoreManagementSystem
{
    public class ShoppingCart
    {
        #region Field

        private Dictionary<Product, int> _productsInCart = new Dictionary<Product, int>();

        #endregion

        #region Constructors

        public ShoppingCart() { }

        public ShoppingCart(Dictionary<Product, int> productsInCart)
        {
            ProductsInCart = productsInCart;
        }

        #endregion

        #region Properties

        public Dictionary<Product, int> ProductsInCart
        {
            get { return _productsInCart; }
            set { _productsInCart = value; }
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
                if (!(ProductsInCart.Keys.Any(p => p.ProductId == id)))
                {
                    throw new ElementNotRegisteredException();
                }

                // Find the element by the id and return
                Product result = null;

                foreach (Product product in ProductsInCart.Keys)
                {
                    if (id == product.ProductId) result = product;
                }

                return result;
            }
        }

        #endregion

        #region Methods

        #region List managers

        public void ShowContents()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            List<Product> temp = ProductsInCart.Keys.ToList();
            temp.Sort();

            foreach (Product product in temp)
            {
                Console.WriteLine($"[{temp.IndexOf(product) + 1}]");

                if (product is Clothes clothes) clothes.ShowContents();
                if (product is Food food) food.ShowContents();
                if (product is PersonalCare personalCare) personalCare.ShowContents();

                Tool.AddLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Add a product to the list « ProductsInCart ». Products will be distinguished by ID.
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Add(Product product)
        {
            if(ProductsInCart.Any())
            {
                // Verify if the product ID already exists in the list
                if (ProductsInCart.Keys.Any(p => p.ProductId == product.ProductId))
                {
                    ProductsInCart[product] += 1;
                    return;
                }
            }
            
            ProductsInCart.Add(product, 1);
            Console.WriteLine($"Product was successfully added to the Cart");
            product.ShowContents();
        }

        /// <summary>
        /// Remove a product from the list « ProductsInCart ». 
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Product product)
        {
            // Verify if the ID does not existe in the list
            if (!(ProductsInCart.Keys.Any(p => p.ProductId == product.ProductId)))
            {
                throw new ElementNotRegisteredException();
            }

            ProductsInCart.Remove(product);
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
            if (!(ProductsInCart.Keys.Any(p => p.ProductId == id)))
            {
                throw new ElementNotRegisteredException();
            }

            ProductsInCart.Remove(this[id]);
            Console.WriteLine($"Product [{id}] was successfully removed");
        }

        /// <summary>
        /// Change the quantity of the product in the shopping cart
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="ElementNotRegisteredException"></exception>
        public void ChangeQuantity(Product product)
        {
            // Verify if the ID does not existe in the list
            if (!(ProductsInCart.Keys.Any(p => p.ProductId == product.ProductId)))
            {
                throw new ElementNotRegisteredException();
            }

            MessageDelegate message = () =>
            {
                Console.WriteLine("How many would you like?");
                Console.WriteLine("If the selected quantity is lower or equal to 0, the article will be deleted");
            };
            Tool.TryGetInt(message, out int result);

            if (result <= 0)
            {
                ProductsInCart.Remove(product);
                Console.WriteLine($"{product.Name} was successfully deleted");
                return;
            }

            ProductsInCart[product] = result;
        }

        public void ChangeQuantity(Guid id)
        {
            // Verify if the ID does not existe in the list
            if (!(ProductsInCart.Keys.Any(p => p.ProductId == id)))
            {
                throw new ElementNotRegisteredException();
            }

            MessageDelegate message = () =>
            {
                Console.WriteLine("How many would you like?");
                Console.WriteLine("If the selected quantity is lower or equal to 0, the article will be deleted");
            };
            Tool.TryGetIntLimitedRange(message, out int result);

            if (result <= 0)
            {
                ProductsInCart.Remove(this[id]);
                return;
            }

            ProductsInCart[this[id]] = result;
        }

        /// <summary>
        /// Return the number of elements in the list « products »
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            if (ProductsInCart is null) return 0;

            return ProductsInCart.Count();
        }

        #endregion

        public bool AddOrToCart(List<Product> Products)
        {
            bool wantSeeCart = false;
            MessageDelegate message = () =>
            {
                Console.WriteLine("To go to cart, push 0");
                Console.WriteLine("To add a product in the cart, choose by number");
            };

            Tool.TryGetIntLimitedRange(message, 0, Products.Count(), out int result);

            if (result == 0)
            {
                wantSeeCart = true;
                return wantSeeCart;
            }
            else
            {
                Add(Products[result -1]);
                return wantSeeCart;
            }
        }

        public bool ManageCartOrPay()
        {
            bool wantPay = false;

            MessageDelegate message = () =>
            {
                Console.WriteLine("To proceed a payment, push 0");
                Console.WriteLine("To manage the quantity of a product, choose by number");
            };

            Tool.TryGetIntLimitedRange(message, 0, ProductsInCart.Count(), out int result);

            if (result == 0)
            {
                wantPay = true;
                return wantPay;
            }
            else
            {
                List<Product> temp = ProductsInCart.Keys.ToList();
                temp.Sort();

                ChangeQuantity(temp[result - 1].ProductId);
            }

            return wantPay;
        }

        #endregion
    }
}
