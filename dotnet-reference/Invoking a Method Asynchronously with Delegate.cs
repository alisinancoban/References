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
        static void Main(string[] args)
        {
            Console.WriteLine("***** Synch Delegate Review *****");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",Thread.CurrentThread.ManagedThreadId);

            BinaryOp binaryOp = new BinaryOp(Add);
            // Once the next statement is processed,
            // the calling thread is now blocked until
            // BeginInvoke() completes.
            IAsyncResult iftAr = binaryOp.BeginInvoke(10, 20,null,null);

            // Do other work on primary thread... This call takes far less than five seconds!
            //Console.WriteLine("Doing more work in Main()!");

            // This message will keep printing until
            // the Add() method is finished.
            while (!iftAr.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(1000);
            }

            //while (!iftAr.AsyncWaitHandle.WaitOne(1000, true)) //maximum wait time
            //{
            //    Console.WriteLine("Doing more work in Main()!");
            //}

            // Now we are waiting again for other thread to complete!
            int answer = binaryOp.EndInvoke(iftAr);
            Console.WriteLine(answer);
        }
        static int Add(int number1, int number2)
        {
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);//Pause 5 seconds
            return number1 + number2;
            
        }
    }
}






