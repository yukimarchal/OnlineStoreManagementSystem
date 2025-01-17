﻿using System;
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

        /// <summary>
        /// Indexer to find a customer by the CustomerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ElementNotRegisteredException"></exception>
        public Customer? this[Guid id]
        {
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

        #region List managers

        /// <summary>
        /// Add a customer to the list « customers ». Customers will be distinguished by ID.
        /// </summary>
        /// <param name="customer"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Add(Customer customer)
        {
            // Verify if the product ID already exists in the list
            if (Customers.Any(c => c.CustomerId == customer.CustomerId))
            {
                throw new ElementAlreadyRegisteredException();
            }

            Customers.Add(customer);
            Console.WriteLine($"Customer was successfully added");
            customer.ShowContents();
        }

        /// <summary>
        /// Remove a customer from the list « customers ». 
        /// </summary>
        /// <param name="customer"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Customer customer)
        {
            // Verify if the ID does not existe in the list
            if (!(Customers.Any(c => c.CustomerId == customer.CustomerId)))
            {
                throw new ElementNotRegisteredException();
            }

            Customers.RemoveAll(c => c.CustomerId == customer.CustomerId);
            Console.WriteLine($"Customer [{customer.CustomerId}] was successfully removed");
        }

        /// <summary>
        /// Remove a customer from the list « customers ».
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Guid id)
        {
            // Verify if the ID does not existe in the list
            if (!(Customers.Any(c => c.CustomerId == id)))
            {             
                throw new ElementNotRegisteredException();
            }

            Customers.Remove(this[id]);
            Console.WriteLine($"Customer [{id}] was successfully removed");
        }

        /// <summary>
        /// Return the number of elements in the list « customers »
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            if(Customers is null) return 0;

            return Customers.Count();
        }
        #endregion

        #region Customer factory

        public static Customer AddCustomer()
        {
            // Create a new instance
            Customer customer = new Customer();

            // Assign fields
            customer.FirstName = AskFirstName();
            customer.LastName = AskLastName();
            customer.Address = AskAddress();

            return customer;
        }

        public static Customer AddCustomer(string email)
        {
            // Create a new instance
            Customer customer = new Customer();

            // Assign fields
            customer.FirstName = AskFirstName();
            customer.LastName = AskLastName();
            customer.Address = AskAddress();
            customer.Email = email;

            return customer;
        }

        /// <summary>
        /// Ask for the first name of the customer
        /// </summary>
        /// <returns></returns>
        public static string AskFirstName()
        {
            Console.Write("First Name : ");
            string firstName = Console.ReadLine();
            return firstName;
        }

        /// <summary>
        /// Ask for the last name of the customer
        /// </summary>
        /// <returns></returns>
        public static string AskLastName()
        {
            Console.Write("Last Name : ");
            string lastName = Console.ReadLine();
            return lastName;
        }

        /// <summary>
        /// Ask for the last name of the customer
        /// </summary>
        /// <returns></returns>
        public static string AskAddress()
        {
            Console.Write("Address : ");
            string address = Console.ReadLine();
            return address;
        }


        #endregion

        #endregion


    }
}
