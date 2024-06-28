using static ToolBox.Delegates;

namespace ToolBox
{
    public static class Tool
    {
        #region Methods

        #region User input

        /// <summary>
        /// Verify if the choice is within the condition, if not it continues to ask for new input
        /// </summary>
        /// <param name="message">message to show before the input</param>
        /// <param name="start">starting number of choice (included)</param>
        /// <param name="end">ending number of choice (included)</param>
        /// <returns>Return true for escape and outputs -1, return false and outputs a number, r</returns>
        public static bool TryGetIntLimitedRange(MessageDelegate message, int start, int end, out int result)
        {
            message();
            result = -1;
            ConsoleKey choice = Console.ReadKey().Key;

            if (choice == ConsoleKey.Escape)
            {
                return true;
            }

            try
            {
                if ((int)choice < start || end < (int)choice)
                {
                    throw new Exception();
                }

                result = (int)choice;
                return false;
            }

            // Ask the user to re-enter input
            catch (Exception)
            {
                ShowErrorMessage("Invalid Input");

                TryGetIntLimitedRange(message, start, end, out result);
            }

            return false;
        }

        public static double GetDouble(MessageDelegate message)
        {
            message();
            try
            {
                double result = double.Parse(Console.ReadLine());
                return result;
            }
            catch (Exception)
            {
                ShowErrorMessage("Invalid entry");
                GetDouble(message);
            }
            return 0;
        }

        #endregion

        #region Console message

        public static void ShowErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = default;

            Thread.Sleep(3000);
            Console.Clear();
        }

        #endregion

        #endregion
    }
}
