using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToolBox.Delegates;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public class OrderManager
    {
        private List<Order> _orders = new List<Order>();

        public List<Order> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        /// <summary>
        /// Indexer to find an Order by the OrderId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ElementNotRegisteredException"></exception>
        public Order? this[Guid id]
        {
            get
            {
                // Verify if the id is not registered
                if (!(Orders.Any(o => o.OrderId == id)))
                {
                    throw new ElementNotRegisteredException();
                }

                // Find the element by the id and return
                Order result = null;

                foreach (Order order in Orders)
                {
                    if (id == order.OrderId) result = order;
                }

                return result;
            }
        }

        public void ShowAllOrders()
        {
            foreach (Order order in Orders)
            {
                double totalPrice = 0;
                //string orderedProducts = "";
                // TODO relire
                string orderedProducts = string.Join(", ", order.OrderedProducts.Select(p => p.Key.Name));
                foreach (Product product in order.OrderedProducts.Keys)
                {
                    totalPrice += product.Price * order.OrderedProducts[product];
                    //orderedProducts += ($"{product.Name}, ");
                }

                Console.WriteLine($"[{Orders.IndexOf(order) + 1}]");

                if (!order.PaymentSucceeded)
                {
                    Console.WriteLine($"Ordered on {order.OrderedDate}");
                    Console.WriteLine($"Total price of the order : {totalPrice}");
                    Console.WriteLine($"Payment stauts : Pending");
                    return;
                }

                if(order.Delivery.DeliveredDate != null)
                {
                    Console.WriteLine($"Delivered on {order.Delivery.DeliveredDate}");
                    Console.WriteLine($"Total price of the order : {totalPrice}");
                    Console.WriteLine($"Payment status : Successfully proceeded");
                    return;
                }

                else
                {
                    Console.WriteLine($"Delivery expected on {order.Delivery.DeliveringDate}");
                    Console.WriteLine($"Total price of the order : {totalPrice}");
                    Console.WriteLine($"Payment status : Successfully proceeded");
                }
            }
        }

        public Order AddOrder(Account currentAccount)
        {
            Order order = new Order();

            order.OrderedDate = DateTime.Now;
            order.OrderedProducts = currentAccount.Cart.ProductsInCart;
            order.Customer = currentAccount.Customer;

            Orders.Add(order);
            return order;
        }

        public Delivery CreateDelivery(Guid orderId)
        {
            // Message to choose the delivery company
            MessageDelegate message = () =>
            {
                Console.WriteLine("Choose the delivery company");
                Console.WriteLine();
                Console.WriteLine("1 : UPS");
                Console.WriteLine("2 : DPD");
                Console.WriteLine("3 : BPost");
                Console.WriteLine("4 : PostNL");
            };

            // Create a new instance
            Delivery delivery = new Delivery();

            // Assign fields
            Tool.TryGetIntLimitedRange(message, 1, 4, out int result);
            delivery.Company = (EnumDeliveryCompany)result;

            delivery.DeliveringDate = (this[orderId]).OrderedDate.AddDays(5);

            return delivery;
        }

        #region Payment

        

        #region List managers

        /// <summary>
        /// Add an Order to the list « orrders ». Orders will be distinguished by ID.
        /// </summary>
        /// <param name="order"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Add(Order order)
        {
            // Verify if the product ID already exists in the list
            if (Orders.Any(o => o.OrderId == order.OrderId))
            {
                throw new ElementAlreadyRegisteredException();
            }

            Orders.Add(order);
            Console.WriteLine($"Order was successfully added");
            //order.ShowContents();
        }

        /// <summary>
        /// Remove an order from the list « orders ». 
        /// </summary>
        /// <param name="order"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Order order)
        {
            // Verify if the ID does not existe in the list
            if (!(Orders.Any(o => o.OrderId == order.OrderId)))
            {
                throw new ElementNotRegisteredException();
            }

            Orders.RemoveAll(o => o.OrderId == order.OrderId);
            Console.WriteLine($"Order [{order.OrderId}] was successfully removed");
        }

        /// <summary>
        /// Remove an order from the list « orders ».
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Guid id)
        {
            // Verify if the ID does not existe in the list
            if (!(Orders.Any(o => o.OrderId == id)))
            {
                throw new ElementNotRegisteredException();
            }

            Orders.Remove(this[id]);
            Console.WriteLine($"Order [{id}] was successfully removed");
        }

        /// <summary>
        /// Return the number of elements in the list « orders »
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            if(Orders is null) return 0;

            int result = Orders.Count();

            return result;
        }
        #endregion

        public void ChoosePayment(Guid orderId)
        {
            MessageDelegate message = () =>
            {
                Console.WriteLine("Choose the payment method by number");
                Console.WriteLine();
                Console.WriteLine("1 : BankContact");
                Console.WriteLine("2 : Credit card");
                Console.WriteLine("3 : Paypal");
            };

            Tool.TryGetIntLimitedRange(message, 1, 3, out int result);
            this[orderId].Payment = (EnumPayment)result;
        }

        public async Task<bool> Pay(Guid orderId)
        {
            bool result = false;
            switch (this[orderId].Payment)
            {
                case EnumPayment.BankContact:
                    BankContact bankContact = new BankContact();
                    result = bankContact.RedirectTo();
                    break;

                case EnumPayment.CreditCard:
                    CreditCard card = new CreditCard();
                    result = card.RedirectTo();
                    break;

                case EnumPayment.Paypal:
                    Paypal paypal = new Paypal();
                    result = paypal.RedirectTo();
                    break;

                default: result = false; break;
            }

            this[orderId].PaymentSucceeded = result;


            return await Task.Run(() =>
            {
                OnPaymentProceeded(orderId);
                return result;
            });
        }


        #region Evenet handler

        public delegate void PaymentProceededEventHandler(Order o);

        public event PaymentProceededEventHandler PaymentProceeded;

        public void OnPaymentProceeded(Guid id)
        {
            if (this[id].PaymentSucceeded)
            {
                PaymentProceeded.Invoke(this[id]);
                AssignOrderInfo(this[id]);
            }
            else
            {
                // throw new PaymentFailedException();
            }
        }

        public Order AssignOrderInfo(Order order)
        {
            order.OrderedDate = DateTime.Now;
            order.Delivery = CreateDelivery(order.OrderId);
            Console.WriteLine($"Estimated delivery date : {order.Delivery.DeliveringDate}");
            return order;

            // Program.Main
            //Order order = new Order();
            //order.Customer = c1;
            //order.OrderedProducts = shoppingCart;

            //ChoosePayment(order.OrderId);
            //order.PaymentSucceeded = Pay(order.OrderId);
        }

        //private static void OrderPaymentProceededHandler(bool paymentSucceeded, EventArgs e)
        //{
        //    CreateOrder(order?????);
        //}

        #endregion

        #endregion
    }
}
