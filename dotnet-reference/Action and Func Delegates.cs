using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Console;
namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            var actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget.Invoke("Action Message", ConsoleColor.Blue, 1);

            var funcTarget1 = new Func<int, int, string>(SumToString);
            //Func<int, int, string> funcAlternative = SumToString;   
            Console.WriteLine(funcTarget1(2,3));

            var funcTarget2 = new Func<int, int, int>(Add);
            Console.WriteLine(funcTarget2.Invoke(4,5));

        }
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            // Restore color.
            Console.ForegroundColor = previous;
        }
        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
        static int Add(int x, int y)
        {
            return x + y;
        }
    }

    
    
}

