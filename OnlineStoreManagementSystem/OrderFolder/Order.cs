using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManagementSystem
{
    public class Order
    {
		private EnumPayment _payment;

		public EnumPayment Payment
		{
			get { return _payment; }
			set { _payment = value; }
		}

		public void ChoosePayment()
		{

		}

		public bool Pay()
		{
			switch (Payment)
			{
				case EnumPayment.BankContact: 
					BankContact bankContact = new BankContact();
					return bankContact.RedirectTo();

				case EnumPayment.Card:
					Card card = new Card();
					return card.RedirectTo();

				case EnumPayment.Paypal:
					Paypal paypal = new Paypal();
					return paypal.RedirectTo();

				default: return false;
			}
		}

	}
}
