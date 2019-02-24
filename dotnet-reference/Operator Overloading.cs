using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Workshop
{
    public delegate string VerySimpleDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            var point1 = new Point(10, 10);
            var point2 = new Point(1, 1);
            point1 = point1 + 5;
            point1 = 5 + point1;
            point1 += point2; // automatically simulated if a type overloads the related binary operator
            Console.WriteLine(point1.X + " " + point1.Y);       
        }

    }
    public class Point:IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.X, this.Y);
        }
        public static Point operator +(int num, Point p2) { return new Point(num + p2.X, num + p2.Y); }
        public static Point operator +(Point p1, int num) { return new Point(p1.X + num, p1.Y + num); }
        public static Point operator +(Point p1, Point p2) { return new Point(p1.X + p2.X, p1.Y + p2.Y); }
        public static Point operator -(Point p1, Point p2) { return new Point(p1.X - p2.X, p1.Y - p2.Y); }
        public static Point operator ++(Point p1) { return new Point(p1.X++, p1.Y++); } //unary operator
        public override bool Equals(object o) { return o.ToString() == this.ToString(); }
        public static bool operator ==(Point p1, Point p2) { return p1.Equals(p2); }
        public static bool operator !=(Point p1, Point p2) { return p1.Equals(p2); }
        public int CompareTo(Point p1)
        {
            if (this.X + this.Y > p1.X + p1.Y) { return 1; }
            else if (this.X + this.Y < p1.X + p1.Y) { return -1; }
            else return 0;
        }



        

    }
}




