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
            var shape = new Shape();
            var form = shape as IDrawToForm;
            form.Draw();
            var memory = shape as IDrawToMemory;
            memory.Draw();
            shape.Draw();
            
        }
    }

    public interface IDrawToForm
    {
        void Draw();
    }
    public interface IDrawToMemory
    {
        void Draw();
    }
    public interface IDrawToPrinter
    {
        void Draw();
    }

    class Shape : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {   // Error! No access modifier!
        //public void IDrawToForm.Draw()
        //{
        //    Console.WriteLine("Which one");
        //}
        /*
           As you can see, when explicitly implementing an interface member, the general pattern breaks down
           to this:
           returnType InterfaceName.MethodName(params){}
           Note that when using this syntax, you do not supply an access modifier; explicitly implemented
           members are automatically private.
           Because explicitly implemented members are always implicitly private, these members are no longer
           available from the object level. In fact, if you were to apply the dot operator to an Octagon type, you would
           find that IntelliSense does not show you any of the Draw() members. As expected, you must use explicit
           casting to access the required functionality. Here’s an example:
        */
        void IDrawToForm.Draw()
        {
            Console.WriteLine("From");
        }
        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Memory");
        }
        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Printer");
        }
    }




}

