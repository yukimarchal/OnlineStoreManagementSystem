using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManagementSystem
{
    public class BankContact : IPayment
    {
        public bool RedirectTo()
        {
            // Redirect the user to the bankcontact payment
            // If the payment is succeeded, return true
            return true;
        }
    }
}
