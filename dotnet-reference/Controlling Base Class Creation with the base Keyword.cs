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
            var sales = new SalesPerson("Mehmet", 34, 3000);
        }
    }

    class Employee //core
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Salary { get; private set; }

        public Employee(string name) : this(name, 0, 0) { }
        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
    }
    class Manager : Employee
    {
        public int StockOptions { get; private set; }

        public Manager(string name, int age, double salary, int stockOption) : base(name, age, salary)
        {
            StockOptions = stockOption;
        }
    }
    class SalesPerson : Employee
    {
        public int SalesNumber { get; private set; }

        public SalesPerson(string name, int age, double salary) : base(name, age, salary) { }
    }




}

