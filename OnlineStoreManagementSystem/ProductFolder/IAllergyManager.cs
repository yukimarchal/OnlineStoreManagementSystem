using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToolBox.Delegates;
using ToolBox;

namespace OnlineStoreManagementSystem
{
    public interface IAllergyManager
    {
        public List<Allergy> MakeAllergyTable()
        {
            // To send as parameter, affect message to show before the user input
            MessageDelegate message = () =>
            {
                Console.WriteLine("Add allergies by numbers. To finish, type Esc key");
                Console.WriteLine();
                Console.WriteLine("1 : Milk");
                Console.WriteLine("2 : Eggs");
                Console.WriteLine("3 : Nuts");
                Console.WriteLine("4 : Sesame");
                Console.WriteLine("5 : Soy");
                Console.WriteLine("6 : Fish");
                Console.WriteLine("7 : Shelfish");
                Console.WriteLine("8 : Wheat");
                Console.WriteLine("9 : Triticale");
                Console.WriteLine("10 : Celery");
                Console.WriteLine("11 : Carrot");
                Console.WriteLine("12 : Avocado");
                Console.WriteLine("13 : Bell_pepper");
                Console.WriteLine("14 : Potato");
                Console.WriteLine("15 : Pumpkin");
                Console.WriteLine("16 : Mushroom");
                Console.WriteLine("17 : Onion");
                Console.WriteLine("18 : Mustard");
                Console.WriteLine("19 : Spices");
            };

            // Create a table and ask users to input as much as colors they want
            List<Allergy> allergies = new List<Allergy>();
            int result;
            bool isEscape;

            do
            {
                // Ask for the choice. Verify the choice with the condition. It continues to ask till obtaining the good choice. In case of escape, it stops registering the colors
                isEscape = Tool.AskValidChocie(message, 1, 19, out result);

                if (!isEscape) allergies.Add((Allergy)result);

            } while (!isEscape);

            return allergies;
        }
    }
}
