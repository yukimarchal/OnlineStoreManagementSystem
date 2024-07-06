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
        public Account? this[string accountId]
        {
            get
            {
                // Verify if the id is not registered
                if (!(Accounts.Any(a => a.AccountId == accountId)))
                {
                    throw new ElementNotRegisteredException();
                }

                // Find the element by the id and return
                foreach (Account account in Accounts)
                {
                    if (account.AccountId == accountId)
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
        /// Add an account to the list « accounts ». Acccounts will be distinguished by Account ID (email).
        /// </summary>
        /// <param name="account"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Add(Account account)
        {
            // Verify if the product ID already exists in the list
            if (Accounts.Any(a => a.AccountId == account.AccountId))
            {
                throw new ElementAlreadyRegisteredException();
            }

            Accounts.Add(account);
            Console.WriteLine($"Account was successfully added");
        }

        /// <summary>
        /// Remove an account from the list « accounts ». 
        /// </summary>
        /// <param name="account"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(Account account)
        {
            // Verify if the ID does not existe in the list
            if (!(Accounts.Any(a => a.AccountId == account.AccountId)))
            {
                throw new ElementNotRegisteredException();
            }

            Accounts.RemoveAll(a => a.AccountId == account.AccountId);
            Console.WriteLine($"Account [{account.AccountId}] was successfully removed");
        }

        /// <summary>
        /// Remove an account from the list « accounts ».
        /// </summary>
        /// <param name="account"></param>
        /// <exception cref="ElementAlreadyRegisteredException"></exception>
        public void Remove(string accountId)
        {
            // Verify if the ID does not existe in the list
            if (!(Accounts.Any(a => a.AccountId == accountId)))
            {
                throw new ElementNotRegisteredException();
            }

            Accounts.Remove(this[accountId]);
            Console.WriteLine($"Account [{accountId}] was successfully removed");
        }

        /// <summary>
        /// Return the number of elements in the list « admins »
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            if(Accounts is null) return 0;
            return Accounts.Count();
        }
        #endregion
    }
}
