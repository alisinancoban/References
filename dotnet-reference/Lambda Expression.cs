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
            var list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Call FindAll() using traditional delegate syntax.
            Predicate<int> callback = IsEvenNumber;
            var evenNumbers1 = list.FindAll(callback);
            //Use an anonymous method
            var evenNumbers2 = list.FindAll(delegate(int i) { return (i % 2) == 0; });
            //Use a lambda expression
            var evenNumbers3 = list.FindAll(i => (i % 2) == 0);
            var evenNumbers4 = list.FindAll((int i) => (i % 2) == 0);
            var evenNumbers5 = list.FindAll(i =>
            {
                Console.WriteLine($"Value of i={i}");
                bool isEven = i % 2 == 0;
                return isEven;
            });

            foreach (int evenNumber in evenNumbers5)
            {
                Console.Write("{0}\t", evenNumber);
            }
        }
        static bool IsEvenNumber(int i) { return (i % 2) == 0; } // Target for the Predicate<> delegate.


    }
}
  

