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
            switch (threadCount)
            {
                case "2":
                    Thread[] threads = new Thread[10];
                    for (int i = 0; i < 10; i++)
                    {
                        threads[i] =
                        new Thread(new ThreadStart(printer.PrintNumbers));
                        threads[i].Name = string.Format("Worker thread #{0}", i);
                    }
                    // Now start each one.
                    foreach (Thread t in threads)
                        t.Start();
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
	
	// All methods of Printer are now thread safe!
	//[Synchronization]
	//public class Printer : ContextBoundObject
    public class Printer
    {
        private object threadLock = new object();

        public void PrintNumbers()
        {
            //lock (threadLock)
            Monitor.Enter(threadLock);
            try
            {
            // Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()",
            Thread.CurrentThread.Name);
                // Print out numbers.
                Console.Write("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    // Put thread to sleep for a random amount of time.
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(threadLock);
            }
        }
    }
}






