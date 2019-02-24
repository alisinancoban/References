using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Linq;
using System.Text;
using CarLibrary;
using System.Reflection.Emit;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using System.Configuration;

namespace Workshop
{
//    A delegate design may be a better choice than an interface design if one or more of
//these conditions are true:
//• The interface defines only a single method.
//• Multicast capability is needed.
//• The subscriber needs to implement the interface multiple times.
    delegate int Transformer(int x);
    public interface ITransformer
    {
        int Transform(int x);
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3 };
            Util.Transform(values, Square);
            foreach (int i in values)
             Console.Write(i + " ");
           

            Util.ITransform(values, new Squarer());
            foreach (int i in values)
                Console.Write(i+ " ");
        }
        static int Square(int x) => x * x;
    }
    class Util
    {
        public static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t(values[i]);
        }

        public static void ITransform(int[] values, ITransformer t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t.Transform(values[i]);
        }
    }
    class Squarer : ITransformer
    {
        public int Transform(int x) => x * x;
    }

}





