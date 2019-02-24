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
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {        
            Console.WriteLine("***** Adding with Thread objects *****");
            Console.WriteLine("ID of thread in Main(): {0}",
            Thread.CurrentThread.ManagedThreadId);

            AddParams addParams = new AddParams(10, 20);
            Thread thread = new Thread(new ParameterizedThreadStart(Add));
			
			//it will shut down immediately does not wait for the other thread to complete
            thread.IsBackground = true; 
            thread.Start(addParams);
           
            Console.WriteLine("Other thread is done");
        }

        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}",
                Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} is {2}",
                ap.number1, ap.number2, ap.number1 + ap.number2);
                Thread.Sleep(5000);
            }
        }
    }
    class AddParams
    {
        public int number1,
                   number2;
        public AddParams(int num1, int num2)
        {
            number1 = num1;
            number2 = num2;
        }
    }   
}






