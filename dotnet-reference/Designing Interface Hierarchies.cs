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
            var image = new BitMapImage();
            image.Draw();
            image.DrawBoundingBox(1, 2, 3, 4);
            image.DrawUpSideDown();
            // Get IDrawable explicitly.
            var draw = image as IDrawable;
            draw.Draw();
        }
    }
    public interface IDrawable
    {
        void Draw();
    }
    public interface IAdvancedDraw
    {
        void DrawBoundingBox(int top, int left, int bottom, int right);
        void DrawUpSideDown();
    }
    public interface IShape:IDrawable, IAdvancedDraw
    {
        void Draw();
        void Delete();
    }

    public class BitMapImage : IShape
    {
        public void Draw() { Console.WriteLine("Drawing"); }
        void IShape.Draw() { Console.WriteLine("IShape Draw"); }
        void IDrawable.Draw() { Console.WriteLine("IDrawable Draw"); }

        public void DrawBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawing in a box");
        }

        public void DrawUpSideDown() { Console.WriteLine("Drawing upside down"); }

        public void Delete() { Console.WriteLine("Deleting"); }
    }


}

