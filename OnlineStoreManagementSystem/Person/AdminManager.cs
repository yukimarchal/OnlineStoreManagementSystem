using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem.Person
{
    public class AdminManager
    {
		private List<Admin> _admins = new List<Admin>();

		public List<Admin> Admins
		{
			get { return _admins; }
			set { _admins = value; }
		}

        /// <summary>
        /// Indexer to find a product by the ProductId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ElementNotRegisteredException"></exception>
        public Admin? this[string email]
		{
			get
			{
                // Verify if the id is not registered
                if (!(Admins.Any(a => a.Email == email)))
				{
                    throw new ElementNotRegisteredException();
                }

                // Find the element by the id and return
                foreach (Admin admin in Admins)
				{
                    if (admin.Email == email)
                    {
						return admin;
                    }
                }

                return null;
			}
		}

        public void AddAdmin()
        {
            Console.Write("Email : ");
            string email = Console.ReadLine();

            // Verify if the product ID already exists in the list
            if (Admins.Any(a => a.Email == email))
            {
                Tool.ShowMessageRed("Email already registered");
                AddAdmin();
            }

            Console.Write("Pass : ");
            string pass = Console.ReadLine();

            Admins.Add(new Admin(email, pass));
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
            if (Admins is null) return 0;

            return Admins.Count();
        }
        #endregion



    }
}
