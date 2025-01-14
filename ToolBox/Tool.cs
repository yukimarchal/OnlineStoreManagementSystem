﻿using static ToolBox.Delegates;

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
            string choice = Console.ReadLine();

            if (choice == "q" || choice == "Q")
            {
                return true;
            }

            try
            {
                if (int.Parse(choice) < start || end < int.Parse(choice))
                {
                    throw new Exception();
                }

                result = int.Parse(choice);
                return false;
            }

            // Ask the user to re-enter input
            catch (Exception)
            {
                ShowMessageRed("Invalid Input");

                TryGetIntLimitedRange(message, start, end, out result);
            }

            return false;
        }
        public static bool TryGetIntLimitedRange(MessageDelegate message, out int result)
        {
            message();
            result = -1;
            string choice = Console.ReadLine();

            if (choice == "q" || choice == "Q")
            {
                return true;
            }

            try
            {
                result = int.Parse(choice);
                Console.WriteLine();
                return false;
            }

            // Ask the user to re-enter input
            catch (Exception)
            {
                ShowMessageRed("Invalid Input");

                TryGetIntLimitedRange(message, out result);
            }

            Console.WriteLine();
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
                ShowMessageRed("Invalid Input");

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
                ShowMessageRed("Invalid entry");
                GetDouble(message);
            }
            return 0;
        }

        #endregion

        #region Console message

        public static void ShowMessageColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowMessageColor(MessageDelegate message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            message();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ShowMessageRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

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
        }
        public static void AddTitle(string Title)
        {
            Console.WriteLine(Line);
            Console.WriteLine(Title);
            Console.WriteLine(Line);
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
