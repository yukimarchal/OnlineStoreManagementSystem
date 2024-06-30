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
            // Redirect the user to the credit card payment
            // If the payment is succeeded, return true
            return true;
        }
    }
}
