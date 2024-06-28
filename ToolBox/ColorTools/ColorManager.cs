using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToolBox.Delegates;

namespace ToolBox
{
    public static class ColorManager
    {
        #region Methods
        /// <summary>
        /// Register as much as colors the user wants in a list and return this
        /// </summary>
        /// <returns></returns>
        public static List<EnumColor> MakeColorTable()
        {
            // To send as parameter, affect message to show before the user input
            MessageDelegate message = () =>
            {
                Console.WriteLine("Add colors by numbers. To finish, type Esc key");
                Console.WriteLine();
                Console.WriteLine("1 : Red");
                Console.WriteLine("2 : Yellow");
                Console.WriteLine("3 : Green");
                Console.WriteLine("4 : Blue");
                Console.WriteLine("5 : Purple");
                Console.WriteLine("6 : Orange");
                Console.WriteLine("7 : Lime");
                Console.WriteLine("8 : Aqua");
                Console.WriteLine("9 : Black");
                Console.WriteLine("10 : White");
                Console.WriteLine("11 : Brown");
                Console.WriteLine("12 : Gray");
                Console.WriteLine("13 : Pink");
                Console.WriteLine("14 : Beige");
            };

            // Create a table and ask users to input as much as enumcolors they want
            List<EnumColor> enumcolors = new List<EnumColor>();
            int result;
            bool isEscape;

            do
            {
                // Ask for the choice. Verify the choice with the condition. It continues to ask till obtaining the good choice. In case of escape, it stops registering
                isEscape = Tool.TryGetIntLimitedRange(message, 1, 14, out result);

                if (!isEscape) enumcolors.Add((EnumColor)result);

            } while (!isEscape);

            return enumcolors;
        }

        #endregion
    }
}
