using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ToolBox.Delegates;

namespace ToolBox
{
    public static class ClothesManager
    {
        #region Methods

        /// <summary>
        /// Ask for the clothes category and return this
        /// </summary>
        /// <returns></returns>
        public static EnumClothes AskClothesCategory()
        {
            // To send as parameter, affect message to show before the user input
            MessageDelegate message = () =>
            Console.WriteLine("Add the category by number");
            Console.WriteLine();
            Console.WriteLine("1 : Dress");
            Console.WriteLine("2 : Blouse");
            Console.WriteLine("3 : T-shirt");
            Console.WriteLine("4 : Pants");
            Console.WriteLine("5 : Skirt");
            Console.WriteLine("6 : Two-pieces");
            Console.WriteLine("7 : Sweater");
            Console.WriteLine("8 : Hoodie");

            // Ask for the choice. Verify the choice with the condition. It continues to ask till obtaining the good choice. In case of escape, it stops registering
            Tool.TryGetIntLimitedRange(message, 1, 8, out int result);

            return (EnumClothes)result;
        }

        #endregion
    }
}
