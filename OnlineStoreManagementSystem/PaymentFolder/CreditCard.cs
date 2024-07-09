using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManagementSystem
{
    public class CreditCard : IPayment
    {
        public bool RedirectTo()
        {
            Console.Clear();
            // Redirect the user to the credit card payment
            // If the payment is succeeded, return true
            Console.WriteLine("Payment is being proceeded");
            Thread.Sleep(3000);

            //Console.WriteLine("The payment was successfully proceeded");
            return true;
        }
    }
}
