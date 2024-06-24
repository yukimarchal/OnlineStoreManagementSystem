using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ToolBox;
using static ToolBox.Delegates;

namespace OnlineStoreManagementSystem.ProductFolder
{
    public interface IColorManager
    {
        public List<Color> MakeColorTable()
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

            // Create a table and ask users to input as much as colors they want
            List<Color> colors = new List<Color>();
            int result;
            bool isEscape;

            do
            {
                // Ask for the choice. Verify the choice with the condition. It continues to ask till obtaining the good choice. In case of escape, it stops registering the colors
                isEscape = Tool.AskValidChocie(message, 1, 14, out result);

                if (!isEscape) colors.Add((Color)result);

            } while (!isEscape);

            return colors;
        }
    }
}
