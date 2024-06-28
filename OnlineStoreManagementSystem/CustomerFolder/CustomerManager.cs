using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public class CustomerManager
    {
        #region Field

        private List<Customer> _customers = new List<Customer>();

        #endregion

        #region Properties

        public List<Customer> Customers
		{
			get { return _customers; }
			set { _customers = value; }
		}

        #endregion

        #region Indexer

        public Customer? this[Guid id]
        {
            /// <summary>
            /// Indexer to find a customer by the CustomerId
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            /// <exception cref="ElementNotRegisteredException"></exception>
            get
            {
                // Verify if the id is not registered
                if (!(Customers.Any(c => c.CustomerId == id)))
                {
                    throw new ElementNotRegisteredException();
                }

                // Find the element by the id and return
                Customer result = null;

                foreach (Customer customer in Customers)
                {
                    if (id == customer.CustomerId) result = customer;
                }

                return result;
            }
        }

        #endregion

        #region Methods



        #endregion


    }
}
