using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public class Food : Product
    {
        #region Field

        private List<EnumAllergy> allergies = new List<EnumAllergy>();

        #endregion

        #region Constructors

        public Food()
        {
            ProductId = Guid.NewGuid();
        }
        public Food(string name, double price, params EnumAllergy[] allergies) : base(name, price)
        {
            ProductId = Guid.NewGuid();

            foreach(EnumAllergy allergy in allergies)
            {
                Allergies.Add(allergy);
            }
        }

        #endregion

        #region Properties

        public List<EnumAllergy> Allergies
        {
            get { return allergies; }

            set { allergies = value; }
        }

        #endregion

        #region Methods

        public override void ShowContents()
        {
            // Make a string with all the registered allergies
            string allergyList = string.Join(", ", Allergies);

            // Show all the contents of this object
            Console.WriteLine($"ID : {ProductId}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Price : {Price}€");
            Console.WriteLine($"Allergies : {allergyList}");
        }

        #endregion
    }
}
