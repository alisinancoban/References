using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Anonymous Types *****\n");
            // Make an anonymous type representing a car.
            var myCar = new { Color = "Bright Pink", Make = "Saab", CurrentSpeed = 55 };
            // Now show the color and make.
            Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Make);
            // Now call our helper method to build anonymous type via args.
            BuildAnonType("BMW", "Black", 90);

            var motorcycle = new { TimeBought = DateTime.Now, Brand = new { Name = "Yamaha", Year = "2018" }, Price = 35000 };

        }

        static void BuildAnonType(string make, string color, int currSp)
        {
            var car = new { Make = make, Color = color, Speed = currSp };
            Console.WriteLine($"You have a {car.Make} {car.Color} goin {car.Speed}");
            Console.WriteLine($"ToString() == {car.ToString()}");
        }
    }

}




