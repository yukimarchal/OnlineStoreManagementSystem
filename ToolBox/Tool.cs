using static ToolBox.Delegates;

namespace ToolBox
{
    public static class Tool
    {
        #region Field

        public static string Line = "______________________________";
        public static string Return = "\n";

        #endregion

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
            ConsoleKeyInfo choice = Console.ReadKey();

            if (choice.Key == ConsoleKey.Escape)
            {
                return true;
            }

            try
            {
                if (int.Parse(choice.KeyChar.ToString()) < start || end < int.Parse(choice.KeyChar.ToString()))
                {
                    throw new Exception();
                }

                result = int.Parse(choice.KeyChar.ToString());
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
        public static bool TryGetIntLimitedRange(MessageDelegate message, out int result)
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
                result = (int)choice;
                return false;
            }

            // Ask the user to re-enter input
            catch (Exception)
            {
                ShowErrorMessage("Invalid Input");

                TryGetIntLimitedRange(message, out result);
            }

            return false;
        }
        public static bool TryGetInt(MessageDelegate message, out int result)
        {
            message();
            result = -1;
            string choice = Console.ReadLine();

            try
            {
                result = int.Parse(choice);
                return false;
            }

            // Ask the user to re-enter input
            catch (Exception)
            {
                ShowErrorMessage("Invalid Input");

                TryGetIntLimitedRange(message, out result);
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

        public static void AddLine()
        {
            AddReturn();
            Console.WriteLine(Line);
            AddReturn();
        }
        public static void AddReturn()
        {
            Console.WriteLine(Return);
            Console.WriteLine(Return);
        }
        public static void AddTitle(string Title)
        {
            Tool.AddReturn();
            Console.WriteLine(Line);
            Console.WriteLine(Title);
            Console.WriteLine(Line);
            Tool.AddReturn();
            AddReturn();
        }

        #endregion

        public static void ReturnToMenu()
        {
            Console.WriteLine("Press any key to go back to the menu");
            Console.ReadLine();
        }

        #endregion
    }
}
