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
            int myInt = 123456789;
            myInt.DisplayDefiningAssembly();
            Console.WriteLine(myInt.ReverseDigits());

            var dataSet = new System.Data.DataSet();
            dataSet.DisplayDefiningAssembly();

            var personel = new Personel("Sinan");
            var personels = new PersonelList();
            personels.Add(personel);
            personels.CallExtensionMethod();

        }
        public static void Add(Personel personel)
        {
            
        }

    }
    static class MyExtension
    {
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine(obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }
        public static int ReverseDigits(this int i)
        {
            char[] digits = i.ToString().ToCharArray();
            Array.Reverse(digits);
            string newDigits = new string(digits);
            return int.Parse(newDigits);
        }
    }
    public class PersonelList : IEnumerable
    {

        List<Personel> staffs = new List<Personel>();
        public void Add(Personel personel)
        {
            staffs.Add(personel);
        }
        public void CallExtensionMethod()
        {
            staffs.PrintDataPersonel();
            staffs.PrintDataIEnumerable();
        }
        public IEnumerator GetEnumerator()
        {
            return staffs.GetEnumerator();
        }
    }
    public class Personel
    {
        public string Name { get; set; }
        public Personel(string name)
        {
            Name = name;
        }

    }

    static class Extensions
    {
        public static void PrintDataPersonel(this List<Personel> personels)
        {
            foreach (var personel in personels) { Console.WriteLine(personel.Name); }
        }
        public static void PrintDataIEnumerable(this IEnumerable<Personel> personels)
        {
            foreach (var personel in personels) { Console.WriteLine(personel.Name); }
        }
    }

}




