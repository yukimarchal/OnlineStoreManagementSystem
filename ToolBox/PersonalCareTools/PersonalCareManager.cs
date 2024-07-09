using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToolBox.Delegates;

namespace ToolBox
{
    public static class PersonalCareManager
    {
        /// <summary>
        /// Ask for the Personal care category and return this
        /// </summary>
        /// <returns></returns>
        public static EnumPersonalCare AskPersonalCareCategory()
        {
            Console.Clear();
            // To send as parameter, affect message to show before the user input
            MessageDelegate message = () =>
            {
                Console.WriteLine("Add the category by number");
                Console.WriteLine();
                Console.WriteLine("1 : Skin care");
                Console.WriteLine("2 : Hair care");
                Console.WriteLine("3 : Hair removal");
                Console.WriteLine("4 : Deodorant");
                Console.WriteLine("5 : Make-up");
                Console.WriteLine("6 : Perfume");
                Console.WriteLine("7 : Body care");
                Console.WriteLine("8 : Nail care");
                Console.WriteLine("9 : Oral care");
                Console.WriteLine();
                Console.Write("Your choice : ");
            };

            // Ask for the choice. Verify the choice with the condition. It continues to ask till obtaining the good choice. In case of escape, it stops registering
            Tool.TryGetIntLimitedRange(message, 1, 9, out int result);
            return (EnumPersonalCare)result;
        }
    }
}
