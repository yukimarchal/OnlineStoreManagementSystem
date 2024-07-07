using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using static ToolBox.Delegates;

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

        public bool LoginOrCreate(ref Account currentAccount)
        {
            bool isLoggedIn;
            MessageDelegate message = () =>
            {
                Console.WriteLine("Are you already a custome of ours?");
                Console.WriteLine("1 : YES. I want to log in");
                Console.WriteLine("2 : NO. I want to creat an account");
            };
            Tool.TryGetIntLimitedRange(message, 1, 2, out int result);

            if (result == 1)  currentAccount = currentAccount.Login(this.Accounts);
            else
            {
                currentAccount = AddAccount();
            }

            isLoggedIn = true;
            return isLoggedIn;
        }

        public Account AddAccount()
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
            return this[email];
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
