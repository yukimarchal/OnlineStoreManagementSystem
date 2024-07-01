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
        private List<Product> _orderedProducts = new List<Product>();
        private Customer _customer;
        private EnumPayment _payment;
		private bool _paymentSucceeded;

		private Delivery _delivery;

        #endregion

        #region Constructors

        internal Order()
		{
			OrderId = Guid.NewGuid();
		}
        public Order(List<Product> orderedProducts, Customer customer, EnumPayment payment)
        {
            OrderId = Guid.NewGuid();
			OrderedDate = DateTime.Now;
			OrderedProducts = orderedProducts;
            Payment = payment;
            Customer = customer;
            //Delivery = CreateDelivery();
            //PaymentSucceeded = Pay();
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

		public List<Product> OrderedProducts
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
            double totalPrice = 0;
            //string orderedProducts = "";
			// TODO relire
            string orderedProducts = string.Join(", ", OrderedProducts.Select(p => p.Name));
            foreach (Product product in OrderedProducts)
            {
                totalPrice += product.Price;
                //orderedProducts += ($"{product.Name}, ");
            }

			//orderedProducts = orderedProducts[..-2];

            Console.WriteLine($"Order ID : {OrderId}");
            Console.WriteLine($"Ordered date : {OrderedDate}");
            Console.WriteLine($"Customer full name : {Customer.FirstName + Customer.LastName}");
            Console.WriteLine($"Payment : {Payment}");
            Console.WriteLine($"Delivery ID : {Delivery.DeliveryId}");
            Console.WriteLine($"Total price of the order : {totalPrice}");
            Console.WriteLine($"Ordered products : {orderedProducts}");
        }

        #endregion
    }
}
