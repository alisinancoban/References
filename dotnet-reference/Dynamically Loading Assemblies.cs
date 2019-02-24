using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Linq;
using System.Text;

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** External Assembly Viewer *****");
            string asmName = "";
            Assembly asm = null;

            do
            {
                Console.WriteLine("Enter an assembly to evaluate");
                asmName = Console.ReadLine();
                try
                {
                    asm = Assembly.Load(asmName);
					//asm = Assembly.Load("CarLibrary");
                    DisplayTypesInAssembly(asm);
                }
                catch
                {
                    Console.WriteLine("Sorry, cant find assembly");
                }
            } while (true);
        }

        static void DisplayTypesInAssembly(Assembly asm)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine($"=>{asm.FullName}");
            Type[] types = asm.GetTypes();
            foreach(Type t in types)
            {
                Console.WriteLine($"Type: {t}");
            }

            //Type types = asm.GetType("CarLibrary.SportsCar", false); //get single type
            //Console.WriteLine(types);
        }
           
    }
}






