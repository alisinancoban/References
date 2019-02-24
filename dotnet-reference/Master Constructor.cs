using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    class Car
    {
        public string PetName { get; private set; }
        public int CurrentSpeed { get; private set; }

        public Car() { Console.WriteLine("In default ctor"); }

        public Car(int speed):this(speed, name:""){ Console.WriteLine("In one parameter ctor"); }
        public Car(string name) : this(default(int),name) { Console.WriteLine("In one parameter ctor"); }

        public Car(int speed, string name)
        {
            Console.WriteLine("Master ctor");
            if (CurrentSpeed > 90)
            {
                speed = 90;
            }
            CurrentSpeed = speed;
            PetName = name;
        }

        

        
    }
}
