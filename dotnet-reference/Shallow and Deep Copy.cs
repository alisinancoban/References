using System;
using System.Collections;
using System.Numerics;
using System.Text;
using static System.Console;
namespace Workshop
{

    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("1", "Sinan", new Address("X Cad", "Izmir"));
            var customerShallow = (Customer)customer.ShallowCopy();
            var customerDepp = customer.DeepCopy();
            customer.Display();
            customerShallow.HomeAddress.City = "Istanbul";
            customer.Display();
            customerShallow.Display();
        }
    }
    class Customer
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public Address HomeAddress { get; set; }
        public Customer(string id, string name, Address address)
        {
            Id = id;
            FullName = name;
            HomeAddress = address;
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        public Customer DeepCopy()
        {
            return new Customer(Id, FullName, HomeAddress);
        }
        public void Display() { Console.WriteLine($"{Id} {FullName} {HomeAddress.City} {HomeAddress.Street}"); }
    }
    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }
    }


    
    
}

