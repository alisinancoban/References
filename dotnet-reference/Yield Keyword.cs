using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;
using CarLibrary;

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string day in GetDays())
            {
                Console.WriteLine(day);
            }
        }

        static IEnumerable<string> GetDays()
        {
            yield return "Pazartesi";
            yield return "Salý";
            yield return "Çarþamba";
            yield return "Perþembe";
            yield return "Cuma";
            yield return "Cumartesi";
            yield break; // yield yapisinin sonlandigini belirtir
            yield return "Pazar";
        }
    }
}






