﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public class Account
    {
        private string _accountId;
        private string _pass;
        private Customer _customer;
        private OrderManager _oManager;
        private ShoppingCart _cart;

        public Account(string pass, Customer customer)
        {
            AccountId = customer.Email;
            Pass = pass;
            Customer = customer;
            OManager = new OrderManager();
            Cart = new ShoppingCart();
        }

        public string AccountId
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
        private string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        public OrderManager OManager
        {
            get { return _oManager; }
            set { _oManager = value; }
        }
        public ShoppingCart Cart
        {
            get { return _cart; }
            set { _cart = value; }
        }

        #region Methods
        public static Account? Login(List<Account> accounts)
        {
            Console.Clear();
            Tool.AddTitle("LOGIN");
            Console.Write("Email : ");
            string email = Console.ReadLine();

            // Verify if the email does not exists in the list
            if ((!accounts.Any(a => a.AccountId == email)))
            {
                Tool.ShowMessageRed("Email not registered.");
                Login(accounts);
            }

            Console.Write("Pass : ");
            string pass = Console.ReadLine();

            foreach (Account account in accounts)
            {
                if (account.AccountId == email)
                {
                    if (pass == account.Pass)
                    {
                        Tool.ShowMessageColor("You are successufully logged in.", ConsoleColor.Green);
                        Thread.Sleep(3000);
                        return account;
                    }
                    else
                    {
                        Tool.ShowMessageRed("The password is not correct.");
                    }
                }
            }
            return null;
        }

        #endregion
    }
}