using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Console;
namespace Workshop
{
    public delegate string VerySimpleDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            var simple = new Simple();
            simple.SetMessageHandler((message, result) => { Console.WriteLine($"{message}{result}"); });
            simple.Add(10, 20);

            simple.SetNoParameterDelegate(() => { Console.WriteLine("No parameter delegate"); });
            simple.NoParameter();

            VerySimpleDelegate d = new VerySimpleDelegate(() => { return "Enjoy your string!"; });
            Console.WriteLine(d());
        }
    }
    class Simple
    {
        public delegate void Message(string message, int result);
        public delegate void NoParameterDelegate();
        private Message mDelegate;
        private NoParameterDelegate npDelegate;
        public void SetNoParameterDelegate(NoParameterDelegate target)
        {
            npDelegate = target;
        }
        public void SetMessageHandler(Message target)
        {
            mDelegate = target;
        }
        public void Add(int num1, int num2)
        {
            mDelegate?.Invoke("Adding has complete ", num1 + num2);
        }
        public void NoParameter()
        {
            npDelegate?.Invoke();
        }
        public int Sum(int num1,int num2) =>  num1 + num2;
        public void PrintSum(int num1, int num2) =>Console.WriteLine(num1 + num2);
        //public int Sum(int num1,int num2) { return num1 + num2; }
        //public void PrintSum(int num1, int num2) { Console.WriteLine(num1 + num2); }

    }


}




