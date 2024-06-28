using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreManagementSystem
{
    public class Customer
    {
        #region Field

        private Guid _customerId;
		private string _firstName;
        private string _lastName;
        private string _address;

        #endregion

        #region Constructors

        private Customer()
        {

        }
        public Customer(string firstName, string lastName, string address)
        {
            CustomerId = new Guid();
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        #endregion

        #region Properties

        public Guid CustomerId
        {
            get { return _customerId; }
            private set { _customerId = value; }
        }
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

        #endregion

        #region Methods

        public void ShowContents()
        {
            Console.WriteLine($"Customer ID : {CustomerId}");
            Console.WriteLine($"First Name : {FirstName}");
            Console.WriteLine($"Last Name : {LastName}");
            Console.WriteLine($"Address : {Address}");
        }

        #endregion
    }
}
