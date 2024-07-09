using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToolBox.Delegates;

namespace ToolBox
{
    public static class AllergyManager
    {
        #region Methods

        /// <summary>
        /// Register as much as allergies the user wants in a list and return this
        /// </summary>
        /// <returns></returns>
        public static List<EnumAllergy> MakeAllergyTable()
        {
            // To send as parameter, affect message to show before the user input
            MessageDelegate message = () =>
            {
                Console.Clear();
                Console.WriteLine("Add allergies by numbers. To finish, type [q]");
                Console.WriteLine();
                Console.WriteLine("1 : Milk");
                Console.WriteLine("2 : Eggs");
                Console.WriteLine("3 : Nuts");
                Console.WriteLine("4 : Sesame");
                Console.WriteLine("5 : Soy");
                Console.WriteLine("6 : Fish");
                Console.WriteLine("7 : Shelfish");
                Console.WriteLine("8 : Pork");
                Console.WriteLine("9 : Beef");
                Console.WriteLine("10 : Chicken");                
                Console.WriteLine("11 : Wheat");
                Console.WriteLine("12 : Triticale");
                Console.WriteLine("13 : Celery");
                Console.WriteLine("14 : Carrot");
                Console.WriteLine("15 : Avocado");
                Console.WriteLine("16 : Bell_pepper");
                Console.WriteLine("17 : Potato");
                Console.WriteLine("18 : Pumpkin");
                Console.WriteLine("19 : Mushroom");
                Console.WriteLine("20 : Onion");
                Console.WriteLine("21 : Mustard");
                Console.WriteLine("22 : Spices");
                Console.WriteLine("23 : None");
                Console.WriteLine();
                Console.WriteLine("Your choice : ");
            };

            // Create a table and ask users to input as much as enumcolors they want
            List<EnumAllergy> allergies = new List<EnumAllergy>();
            int result;
            bool isEscape;

            do
            {
                // Ask for the choice. Verify the choice with the condition. It continues to ask till obtaining the good choice. In case of escape, it stops registering
                isEscape = Tool.TryGetIntLimitedRange(message, 1, 23, out result);

                if (!isEscape) allergies.Add((EnumAllergy)result);

            } while (!isEscape);

            return allergies;
        }

        #endregion
    }
}
