using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class SubConsole
    {
        /// <summary>
        /// This method logs errror messages to the console. 
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="delay"></param>
        public static void LogErr(string msg, int delay)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Thread.Sleep(delay);
            Console.ResetColor();
            Console.Clear();
        }

        /// <summary>
        /// This method gets an integer value from the user. We use this method top validate user input 
        ///  in the form of an int throughout the application. 
        /// </summary>
        /// <param name="str">A message that asks for the integer</param>
        /// <returns>-1 if an invalid selection is chosen else the number entered</returns>
        public static int GetIntIn(string str)
        {
            Console.Write(str);
            string in_as_num = Console.ReadLine() ?? "";
            if (in_as_num == "")
            {
                return -1;
            }
            int @return = -1;
            try
            {
                @return = Convert.ToInt32(in_as_num);
            }
            catch (FormatException)
            {
                return -1;
            }
            return @return;
        }
    }
}