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
            Console.WriteLine("***** Synch Delegate Review *****");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",Thread.CurrentThread.ManagedThreadId);

            BinaryOp binaryOp = new BinaryOp(Add);
            IAsyncResult iftAr = binaryOp.BeginInvoke(10, 20, new AsyncCallback(AddComplete), "Main() thanks you for adding these numbers");

            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working....");
            }
        }
        static int Add(int number1, int number2)
        {
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);//Pause 5 seconds
            return number1 + number2;
            
        }

        static void AddComplete(IAsyncResult itfAR)
        {
            string message = (string)itfAR.AsyncState;
            Console.WriteLine(message);
            Console.WriteLine("AddComplete() invoked on thread {0}.",Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            isDone = true;
        }
    }
}






