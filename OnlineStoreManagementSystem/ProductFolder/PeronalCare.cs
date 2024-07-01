using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public class PersonalCare : Product
    {
        #region Field

        private EnumPersonalCare _personalCareCategory;
        private List<EnumColor> _colors = new List<EnumColor>();
        private List<EnumAllergy> allergies = new List<EnumAllergy>();

        #endregion

        #region Constructors
        public PersonalCare()
        {
            ProductId = Guid.NewGuid();
        }

        // Base
        public PersonalCare(string name, double price, EnumPersonalCare personalCareCategory, params EnumAllergy[] allergies) : base(name, price)
        {
            ProductId = Guid.NewGuid();
            PersonalCareCategory = personalCareCategory;

            foreach (EnumAllergy allergy in allergies)
            {
                Allergies.Add(allergy);
            }
        }

        // Base + 1 color
        public PersonalCare(string name, double price, EnumPersonalCare personalCareCategory, EnumColor enumcolor1, params EnumAllergy[] allergies) : base(name, price)
        {
            ProductId = Guid.NewGuid();
            PersonalCareCategory = personalCareCategory;
            Colors.Add(enumcolor1);

            foreach (EnumAllergy allergy in allergies)
            {
                Allergies.Add(allergy);
            }
        }

        // Base + 2 colors
        public PersonalCare(string name, double price, EnumPersonalCare personalCareCategory, EnumColor enumcolor1, EnumColor enumcolor2, params EnumAllergy[] allergies) : base(name, price)
        {
            ProductId = Guid.NewGuid();
            PersonalCareCategory = personalCareCategory;
            Colors.Add(enumcolor1);
            Colors.Add(enumcolor2);

            foreach (EnumAllergy allergy in allergies)
            {
                Allergies.Add(allergy);
            }
        }

        // Base + 3 colors
        public PersonalCare(string name, double price, EnumPersonalCare personalCareCategory, EnumColor enumcolor1, EnumColor enumcolor2, EnumColor enumcolor3, params EnumAllergy[] allergies) : base(name, price)
        {
            ProductId = Guid.NewGuid();
            PersonalCareCategory = personalCareCategory;
            Colors.Add(enumcolor1);
            Colors.Add(enumcolor2);
            Colors.Add(enumcolor3);

            foreach (EnumAllergy allergy in allergies)
            {
                Allergies.Add(allergy);
            }
        }

        #endregion

        #region Properties

        public EnumPersonalCare PersonalCareCategory
        {
            get { return _personalCareCategory; }
            set { _personalCareCategory = value; }
        }

        public List<EnumColor> Colors
        {
            get { return _colors; }
            set { _colors = value; }
        }
        public List<EnumAllergy> Allergies
        {
            get { return allergies; }

            set { allergies = value; }
        }

        #endregion

        #region Methods

        public override void ShowContents()
        {
            // Make a string with all the registered colors
            string colorList = "";
            foreach (EnumColor color in Colors)
            {
                colorList += color.ToString();
                colorList += ", ";
            }

            // Make a string with all the registered allergies
            string allergyList = "";
            foreach (EnumAllergy allergy in Allergies)
            {
                allergyList += allergy.ToString();
                allergyList += ", ";
            }

            // Show all the contents of this object
            Console.WriteLine($"ID : {ProductId}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Price : {Price}");
            Console.WriteLine($"Personal care category : {PersonalCareCategory}");
            Console.WriteLine($"Colors : {colorList}");
            Console.WriteLine($"Alergies : {allergyList}");
        }

        #endregion
    }
}
