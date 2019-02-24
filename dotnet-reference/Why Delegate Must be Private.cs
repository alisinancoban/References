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
            Console.WriteLine("***** Agh! No Encapsulation! *****\n");
            // Make a Car.
            Motorcycle moto = new Motorcycle();
            // We have direct access to the delegate!
            moto.listOfHandlers = new Motorcycle.MotorcycleEngineHandler(CallWhenExploded);
            moto.Accelerate(10);
            // We can now assign to a whole new object...
            // confusing at best.
            moto.listOfHandlers = new Motorcycle.MotorcycleEngineHandler(CallHereToo);
            moto.Accelerate(10);
            // The caller can also directly invoke the delegate!
            moto.listOfHandlers.Invoke("hee, hee, hee...");
            Console.ReadLine();
        }
        static void CallWhenExploded(string msg)
        { Console.WriteLine(msg); }
        static void CallHereToo(string msg)
        { Console.WriteLine(msg); }

    }

    class Motorcycle
    {
        public delegate void MotorcycleEngineHandler(string msgForCaller);
        public MotorcycleEngineHandler listOfHandlers;        // Now a public member!
        public void Accelerate(int delta)
        {
            if (listOfHandlers != null)
                listOfHandlers("Sorry, this car is dead...");
        }
    }
}

    
  

