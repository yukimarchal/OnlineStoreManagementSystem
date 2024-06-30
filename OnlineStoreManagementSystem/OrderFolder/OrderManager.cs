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
        private List<Order> _orderes = new List<Order>();

        public List<Order> Orderes
        {
            get { return _orderes; }
            set { _orderes = value; }
        }

        public Order? this[Guid id]
        {
            get
            {
                // Verify if the id is not registered
                if (!(Orderes.Any(o => o.OrderId == id)))
                {
                    throw new ElementNotRegisteredException();
                }

                // Find the element by the id and return
                Order result = null;

                foreach (Order order in Orderes)
                {
                    if (id == order.OrderId) result = order;
                }

                return result;
            }
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

        public bool Pay(Guid orderId)
        {
            switch (this[orderId].Payment)
            {
                case EnumPayment.BankContact:
                    BankContact bankContact = new BankContact();
                    return bankContact.RedirectTo();

                case EnumPayment.CreditCard:
                    CreditCard card = new CreditCard();
                    return card.RedirectTo();

                case EnumPayment.Paypal:
                    Paypal paypal = new Paypal();
                    return paypal.RedirectTo();

                default: return false;
            }
        }

        #endregion
    }
}
