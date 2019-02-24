using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Console;
namespace Workshop
{
    // Test
    // Summary:Main Class
    //         Starting Point of Application
    // 
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 20;
            GenericMethods.Swap<int>(ref a, ref b);
            Console.WriteLine(a +" " + b);
            GenericMethods.DisplayBaseClass<System.ValueType>();

            Point<int, Dot> point = new Point<int, Dot>();
            //Point<int, string> point = new Point<int, string>();
            //Point<string, int> point = new Point<string, int>(); compile time error!!
        }

        
    }

    static class GenericMethods
    {
        public static void Swap<T>(ref T item1, ref T item2) where T: struct //only swap value types
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }

        public static void DisplayBaseClass<T>()
        {
            Console.WriteLine("Base class of {0} is: {1}.",
            typeof(T), typeof(T).BaseType);
        }
    }

    public struct Point<T,U> where T : struct where U : class, IComparable, new() //new must be last
    {
        private T Xpos;
        private U Ypos;
        public Point(T xVal, U yVal)
        {
            Xpos = xVal;
            Ypos = yVal;
        }
        public T X { get { return Xpos; } set { Xpos = value; } }
        public U Y { get { return Ypos; } set { Ypos = value; } }
        public override string ToString()
        {
            return string.Format($"X:{Xpos} and Y:{Ypos}");
        }
        public void ResetPoint(){Xpos = default(T); Ypos = default(U); }
    }
    class Dot : IComparable
    {
        public int PinPoint { get; private set; }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public Dot() { }
    }

}

