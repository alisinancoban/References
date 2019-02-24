using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Linq;
using System.Text;
using CarLibrary;

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            SportsCar sc = new SportsCar();
            Type t = sc.GetType();

            Type t2 = Type.GetType("CarLibrary.SportsCar, CarLibrary", false,true); //external assembly
            Type t3 = Type.GetType("CarLibrary.Car, CarLibrary", false,true); //external assembly
            Type t4 = Type.GetType("Workshop.Motorcycle", false, true); //this assembly
            Console.WriteLine(t2);
            Console.WriteLine(t3);

            ListMethods(t2);
            ListFields(t3);
            ListProps(t3);
            ListVariousStats(t2);

            ListFields(Type.GetType("System.Math"));
        }

        static void ListMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            MethodInfo[] mi = t.GetMethods();
            foreach(var info in mi)
            {
                //Console.WriteLine($"=> {info.Name}");
                string returnValue = info.ReturnType.FullName;
                string paramInfo = "( ";
                // Get params.
                foreach (ParameterInfo pi in info.GetParameters()){paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);}paramInfo += " )";
                Console.WriteLine($"=>{returnValue} {info.Name} {paramInfo}");
            }
        }
        static void ListFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            var fieldNames = t.GetFields().Select(f => f.Name);
            foreach (var name in fieldNames)
                Console.WriteLine($"->{name}");
            Console.WriteLine();
        }
        static void ListProps(Type t)
        {
            Console.WriteLine("***** Properties *****");
            var propNames = t.GetProperties().Select(p => p.Name);
            foreach (var name in propNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }
        static void ListVariousStats(Type t) //Displaying Various Odds and Ends
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type? {0}", t.IsClass);
            Console.WriteLine();
        }
    }

    class Motorcycle
    {

    }
}






