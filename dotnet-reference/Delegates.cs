using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Console;
namespace Workshop
{
    public delegate void EventHandler(string msgForCaller);
    public delegate void MotorcycleHandler(string msgForCaller);
    class Program
    {
        static void Main(string[] args)
        {
            Motorcycle moto = new Motorcycle("Yamaha", 200, 100);
            moto.RegisterWithMotorcyleEngine(OnMotorcycleEngineEvent);  //Method Group Conversion Syntax
            
            moto.RegisterWithMotorcyleEngine(new Motorcycle.MotorcycleHandler(OnMotorcycleEngineStop));
            //moto.RegisterWithMotorcyleEngine(new MotorcycleHandler(OnMotorcycleEngineStop)); if delegate global

            Motorcycle.MotorcycleHandler handler = OnMotorcycleEngineStop; //type Motorcycle.MotorcycleHandler
            //Motorcycle.MotorcycleHandler handler = new Motorcycle.MotorcycleHandler(OnMotorcycleEngineStop);
            moto.RegisterWithMotorcyleEngine(handler);
            //moto.UnRegisterWithMotorcyleEngine(handler);

            EventHandler handler2 = OnMotorcycleEngineStop;
            moto.RegisterWithMotorcyleEngine(hadnler2); //type EventHandler

            MotorcycleHandler handler3 = OnMotorcycleEngineStop;
            moto.RegisterWithMotorcyleEngine(handler3); //type MotorcycleHandler

            for (int i = 0; i < 6; i++)
                moto.Accelerate(20);
            Console.ReadLine();
        }
        public static void OnMotorcycleEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Motorcycle Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }
        public static void OnMotorcycleEngineStop(string msg)
        {
            Console.WriteLine("=> {0}",msg.ToUpper());
        }
    }
    public class Motorcycle
    {
        public delegate void MotorcycleHandler(string msgForCaller); //define a delegate type
        private MotorcycleHandler motorcycleHandler; //Define a member variable of this delegate.
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // Is the car alive or dead?
        private bool carIsDead;
        // Class constructors.
        public Motorcycle() { }
        public Motorcycle(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        public void RegisterWithMotorcyleEngine(MotorcycleHandler methodToCall) //Add registration function for the caller.
        {
            motorcycleHandler += methodToCall;
            //Delegate.Combine(motorcycleHandler, methodToCall);
        }
        public void UnRegisterWithMotorcyleEngine(MotorcycleHandler methodToCall) //Remove registration function
        {
            motorcycleHandler -= methodToCall;
        }
        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                if (motorcycleHandler != null)
                    motorcycleHandler("Sorry, this motorcycle is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) // Is this car "almost dead"?
                && motorcycleHandler != null)
                {
                    motorcycleHandler("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }


    }
    
}

