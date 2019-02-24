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
            var threeDCircle = new ThreeDCircle();
            threeDCircle.Draw();

            Circle circle = new ThreeDCircle();
            circle.Draw();
        }
    }
    class ThreeDCircle : Circle
    {
        // Hide any Draw() implementation above me.
        public new void Draw()
        {
            Console.WriteLine("ThreeDCircle");
        }
    }
    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }
    abstract class Shape
    {
        // Force all child classes to define how to be rendered.
        public abstract void Draw();
}
}

