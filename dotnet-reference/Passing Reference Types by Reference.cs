using System;
using System.Numerics;
using System.Text;
namespace Workshop
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            Person sinan = new Person("Sinan", 23);
            sinan.Display();

            SendAPersonByValue(ref sinan);
            sinan.Display();
        }

        static void SendAPersonByValue(ref Person p)
        {
            // Change the age of "p"?
            p.personAge = 99;
            // Will the caller see this reassignment?
            p = new Person("Nikki", 99);
        }
    }

    class Person
    {
        public string personName;
        public int personAge;
        // Constructors.
        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }
        public Person() { }
        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }
    }
}

