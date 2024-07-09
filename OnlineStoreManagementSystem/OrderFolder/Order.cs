using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ToolBox;
using static ToolBox.Delegates;

namespace OnlineStoreManagementSystem
{
    public class Order
    {
        #region Fields

        private Guid _orderId;
        private DateTime _orderedDate;
        private Dictionary<Product, int> _orderedProducts = new Dictionary<Product, int>();
        private Customer _customer;
        private EnumPayment _payment;
		private bool _paymentSucceeded;

		private Delivery _delivery;

        #endregion

        #region Constructors

        public Order()
		{
			OrderId = Guid.NewGuid();
		}
        public Order(Dictionary<Product, int> orderedProducts, Customer customer)
        {
            OrderId = Guid.NewGuid();
            OrderedDate = DateTime.Now;
            OrderedProducts = orderedProducts;
            Customer = customer;
            //Delivery = CreateDelivery();
            //PaymentSucceeded = Pay();
        }
        public Order(Dictionary<Product, int> orderedProducts, Customer customer, EnumPayment payment)
        {
            OrderId = Guid.NewGuid();
			OrderedDate = DateTime.Now;
			OrderedProducts = orderedProducts;
            Payment = payment;
            Customer = customer;
            //Delivery = CreateDelivery();
            //PaymentSucceeded = Pay();
        }

        public Order(DateTime orderedDate, Dictionary<Product, int> orderedProducts, Customer customer, EnumPayment payment, Delivery delivery, bool paymentSucceeded)
        {
            OrderId = Guid.NewGuid();
            OrderedDate = orderedDate;
            OrderedProducts = orderedProducts;
            Customer = customer;
            Payment = payment;
            Delivery = delivery;
            PaymentSucceeded = paymentSucceeded;
        }



        #endregion

        #region Properties

        public Guid OrderId
		{
			get { return _orderId; }
			private set { _orderId = value; }
		}
		public DateTime OrderedDate
		{
			get { return _orderedDate; }
			set { _orderedDate = value; }
		}

		public Dictionary<Product, int> OrderedProducts
		{
			get { return _orderedProducts; }
			set { _orderedProducts = value; }
		}
        public Customer Customer
		{
			get { return _customer; }
			set { _customer = value; }
		}
        public EnumPayment Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }
		public Delivery Delivery
		{
			get { return _delivery; }
			set { _delivery = value; }
		}
        public bool PaymentSucceeded
        {
            get { return _paymentSucceeded; }
            set { _paymentSucceeded = value; }
        }

        #endregion

        #region Methods

  //      public Delivery CreateDelivery()
		//{
		//	// Message to choose the delivery company
		//	MessageDelegate message = () =>
		//	{
		//		Console.WriteLine("Choose the delivery company");
  //              Console.WriteLine();
  //              Console.WriteLine("1 : UPS");
  //              Console.WriteLine("2 : DPD");
  //              Console.WriteLine("3 : BPost");
  //              Console.WriteLine("4 : PostNL");
  //          };

		//	// Create a new instance
		//	Delivery delivery = new Delivery();

		//	// Assign fields
		//	Tool.TryGetIntLimitedRange(message, 1, 4, out int result);
  //          delivery.Company = (EnumDeliveryCompany)result;

		//	delivery.DeliveringDate = OrderedDate.AddDays(5);

  //          return delivery;
		//}

		#region Payment

		//public void ChoosePayment()
		//{
		//	MessageDelegate message = () =>
		//	{
		//		Console.WriteLine("Choose the payment method by number");
		//		Console.WriteLine();
		//		Console.WriteLine("1 : BankContact");
  //              Console.WriteLine("2 : Credit card");
  //              Console.WriteLine("3 : Paypal");
  //          };

		//	Tool.TryGetIntLimitedRange(message, 1, 3, out int result);
		//	Payment = (EnumPayment)result;
		//}

		//public bool Pay()
		//{
		//	switch (Payment)
		//	{
		//		case EnumPayment.BankContact: 
		//			BankContact bankContact = new BankContact();
		//			return bankContact.RedirectTo();

		//		case EnumPayment.CreditCard:
		//			CreditCard card = new CreditCard();
		//			return card.RedirectTo();

		//		case EnumPayment.Paypal:
		//			Paypal paypal = new Paypal();
		//			return paypal.RedirectTo();

		//		default: return false;
		//	}
		//}

        #endregion

        public void ShowContents()
        {
			Console.Clear();

			Tool.AddTitle("ORDER DETAIL");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            double totalPrice = 0;
            //string orderedProducts = "";
            string orderedProducts = string.Join(", ", OrderedProducts.Select(p => p.Key.Name));
            foreach (Product product in OrderedProducts.Keys)
            {
                totalPrice += product.Price * OrderedProducts[product];
                //orderedProducts += ($"{product.Name}, ");
            }

			//orderedProducts = orderedProducts[..-2];

            Console.WriteLine($"Order ID : {OrderId}");
            Console.WriteLine($"Ordered date : {OrderedDate}");
            Console.WriteLine($"Customer full name : {Customer.FirstName} {Customer.LastName}");
            Console.WriteLine($"Payment : {Payment}");

			if (PaymentSucceeded)
			{
				Console.WriteLine($"Payment status : Successfully proceeded");
				Console.WriteLine($"Delivery ID : {Delivery.DeliveryId}");
				Console.WriteLine($"Delivery Company : {Delivery.Company}");

				if (Delivery.DeliveredDate is null) Console.WriteLine($"Expected delivery date : {Delivery.DeliveringDate}");
				else Console.WriteLine($"Delivered date : {Delivery.DeliveredDate}");
			}

			else Console.WriteLine($"Payment status : Pending");

            Console.WriteLine($"Total price of the order : {totalPrice}");
            Console.WriteLine($"Ordered products : {orderedProducts}");

			Console.ForegroundColor = default;
        }

        #endregion
    }
}
