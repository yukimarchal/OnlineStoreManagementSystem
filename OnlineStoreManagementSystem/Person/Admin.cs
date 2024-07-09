using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public class Admin
    {
        #region Fields

        private string _email;
		private string _pass;

        #endregion

        #region Constructors

        public Admin(string email, string pass)
        {
            Email = email;
            Pass = pass;
        }

        #endregion

        #region Properties

        public string Email
		{
			get { return _email; }
			private set { _email = value; }
		}
        private string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        #endregion

        #region Methods

        public static Admin? Login(List<Admin> admins)
        {
            Console.Clear();

            Tool.AddTitle("LOGIN AS ADMIN");
            Console.Write("Email : ");
            string email = Console.ReadLine();

            // Verify if the email does not exists in the list
            if ((!admins.Any(a => a.Email == email)))
            {
                Tool.ShowMessageRed("Email not registered.");
                Login(admins);
            }

            Console.Write("Pass : ");
            string pass = Console.ReadLine();

            foreach (Admin admin in admins)
            {
                if(admin.Email == email)
                {
                    if(pass == admin.Pass)
                    {
                        Tool.ShowMessageColor("You are successufully logged in.", ConsoleColor.Green);
                        Thread.Sleep(3000);
                        return admin;
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
