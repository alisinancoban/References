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
            int counter = 0;
            var car = new Car(100, 200);
            car.AboutToBlow += CarAboutToBlow;
            car.AboutToBlow += CarAboutToBlow;
            car.Exploded += Car_Exploded; // += then press tab

            car.Exploded += delegate (object sender, CarEventArgs e) //Anonymouse method
            {
                Console.WriteLine("Anonymous meyhod");
                counter++;
                
            };

            car.AboutToBlow += delegate { Console.WriteLine("ASC"); counter++; };

            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
               car.Accelerate(20);
            
            car.Exploded -= Car_Exploded; // Remove CarExploded method from invocation list.
            Console.WriteLine("\n***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                car.Accelerate(20);

            Console.WriteLine("Counter "+counter);
        }

        private static void Car_Exploded(object sender, CarEventArgs args) //automatically created
        {
            if(sender is Car)
            {
                Console.WriteLine(((Car)sender).CurrentSpeed);
            }
        }

        public static void CarAboutToBlow(object sender, CarEventArgs args)
        { Console.WriteLine(args.message); }
        public static void CarIsAlmostDoomed(object sender, CarEventArgs args)
        { Console.WriteLine("=> Critical Message from Car: {0}", args); }
    }
    class Car
    {
        public int CurrentSpeed { get; private set; }
        public int MaxSpeed { get; private set; }
        private bool carIsDead;

        public delegate void CarEngineHandler(object sender, CarEventArgs args);

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        public void Accelerate(int delta)
        {
            // If the car is dead, fire Exploded event.
            if (carIsDead)
            {
                //if (Exploded != null)
                    Exploded?.Invoke(this,new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
            // Almost dead?
                if (20 == MaxSpeed - CurrentSpeed && AboutToBlow != null)
                {
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
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
    public class CarEventArgs : EventArgs
    {
        public readonly string message;
        public CarEventArgs(string message) { this.message = message; }
    }
}

    
  

