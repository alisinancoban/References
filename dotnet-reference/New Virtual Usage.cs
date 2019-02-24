using System;
using System.Numerics;
using System.Text;
using static System.Console;
namespace Workshop
{

    class Program
    {       
        static void Main(string[] args)
        {
            Employee emp1 = new Manager("name", 1, 1,1);
            Manager emp2 = new Manager("name", 2, 2, 2);

            emp1.Display();
            emp2.Display();


        }
    }

    class Employee //core
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        protected double Salary { get; private set; }

        public Employee(string name) : this(name, 0, 0) { }
        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{Name}{Age}{Salary}");
        }
    }
    class Manager : Employee
    {
        public int StockOptions { get; private set; }

        public Manager(string name, int age, double salary, int stockOption) : base(name, age, salary)
        {
            StockOptions = stockOption;
        }

        public new virtual void Display()
        {
            Console.WriteLine($"{Name}{Age}{Salary}{StockOptions}");
        }

    }




}

