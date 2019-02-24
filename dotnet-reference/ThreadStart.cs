using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Linq;
using System.Text;
using CarLibrary;
using System.Reflection.Emit;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace Workshop
{
    public delegate int BinaryOp(int number1, int number2);
    class Program
    {
        private static bool isDone = false;

        static void Main(string[] args)
        {
            Console.WriteLine("***** The Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads? ");
            string threadCount = Console.ReadLine();
            // Name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            var printer = new Printer();
            switch(threadCount)
            {
                case "2":
                    Thread backgroundThread =new Thread(new ThreadStart(printer.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                    printer.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("Wrong entry");
                    break;
            }

            MessageBox.Show("I`m busy!, Work on main thread...");

        }
        
    }
    public class Printer
    {
        public void PrintNumbers()
        {
            // Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()",
            Thread.CurrentThread.Name);
            // Print out numbers.
            Console.Write("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}






