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
            var car = new Car(100, 200);
            car.AboutToBlow += CarIsAlmostDoomed;
            car.AboutToBlow += CarAboutToBlow;
            car.Exploded += Car_Exploded; // += then press tab

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
               car.Accelerate(20);
            
            car.Exploded -= Car_Exploded; // Remove CarExploded method from invocation list.
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                car.Accelerate(20);
            Console.ReadLine();
        }

        private static void Car_Exploded(string message) //automatically created
        {
            Console.WriteLine(message);
        }

        public static void CarAboutToBlow(string message)
        { Console.WriteLine(message); }
        public static void CarIsAlmostDoomed(string message)
        { Console.WriteLine("=> Critical Message from Car: {0}", message); }
    }
    class Car
    {
        public int CurrentSpeed { get; private set; }
        public int MaxSpeed { get; private set; }
        private bool carIsDead;

        public delegate void CarEngineHandler(string message);

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        public void Accelerate(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
            // Almost dead?
                if (20 == MaxSpeed - CurrentSpeed && AboutToBlow != null)
                {
                    AboutToBlow("Careful buddy! Gonna blow!");
                }
                // Still OK!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
        public Car(int current, int max)
        {
            CurrentSpeed = current;
            MaxSpeed = max;
            carIsDead = false;
        }
    }
}

    
  

