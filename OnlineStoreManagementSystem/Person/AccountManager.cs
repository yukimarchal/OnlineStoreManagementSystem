using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem.Person
{
    public class AccountManager
    {
        private List<Account> _accounts = new List<Account>();

        public List<Account> Accounts
        {
            get { return _accounts; }
            set { _accounts = value; }
        }

        /// <summary>
        /// Indexer to find an account by the AccountId (email)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ElementNotRegisteredException"></exception>
        public Account? this[string id]
        {
            get
            {
                // Verify if the id is not registered
                if (!(Accounts.Any(a => a.AccountId == id)))
                {
                    throw new ElementNotRegisteredException();
                }

                // Find the element by the id and return
                foreach (Account account in Accounts)
                {
                    if (account.AccountId == id)
                    {
                        return account;
                    }
                }

                return null;
            }
        }

        public void AddAccount()
        {
            Console.Write("Email : ");
            string email = Console.ReadLine();

            // Verify if the account ID (email) already exists in the list
            if (Accounts.Any(a => a.AccountId == email))
            {
                Tool.ShowErrorMessage("Email already registered");
                AddAccount();
            }

            Console.Write("Pass : ");
            string pass = Console.ReadLine();

            Accounts.Add(new Account(pass, CustomerManager.AddCustomer()));
        }

        #region List managers

        /// <summary>
        /// Add an admin to the list « admins ». Admins will be distinguished by Email.
        /// </summary>
        /// <param name="admin"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Add(Admin admin)
        {
            // Verify if the product ID already exists in the list
            if (Admins.Any(a => a.Email == admin.Email))
            {
                throw new ElementAlreadyRegisteredException();
            }

            Admins.Add(admin);
            Console.WriteLine($"Admin was successfully added");
        }

        /// <summary>
        /// Remove an admin from the list « admins ». 
        /// </summary>
        /// <param name="admin"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Admin admin)
        {
            // Verify if the ID does not existe in the list
            if (!(Admins.Any(a => a.Email == admin.Email)))
            {
                throw new ElementNotRegisteredException();
            }

            Admins.RemoveAll(a => a.Email == admin.Email);
            Console.WriteLine($"Admin [{admin.Email}] was successfully removed");
        }

        /// <summary>
        /// Remove an admin from the list « admins ».
        /// </summary>
        /// <param name="email"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(string email)
        {
            // Verify if the ID does not existe in the list
            if (!(Admins.Any(a => a.Email == email)))
            {
                throw new ElementNotRegisteredException();
            }

            Admins.Remove(this[email]);
            Console.WriteLine($"Admin [{email}] was successfully removed");
        }

        /// <summary>
        /// Return the number of elements in the list « admins »
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return Admins.Count();
        }
        #endregion
    }
}
