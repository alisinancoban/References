using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

/* CUSTOM NAMESPACES */
using MyShapes;
using My3DShapes;
using NestedNameSpace.NestedShapes;
using NameSpace.MyShapes;

using The3DHexagon = My3DShapes.Hexagon; //aliases

namespace Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle1 = new MyShapes.Circle();
            var circle2 = new My3DShapes.Circle();

            The3DHexagon hexagon = new The3DHexagon();


        }
    }
}
namespace MyShapes
{
    
    public class Circle { }// Circle class
    public class Hexagon { }// Hexagon class
    public class Square { }// Square class
}
namespace My3DShapes
{
    
    public class Circle { }// 3D Circle class.
    public class Hexagon { }// 3D Hexagon class.
    public class Square { }// 3D Square class.
}
namespace NestedNameSpace
{
    namespace NestedShapes
    {
        public class Circle { }
        public class Hexagon { }
        public class Square { }
    }
}

namespace NameSpace.MyShapes
{
    public class Circle { }
    public class Hexagon { }
    public class Square { }
}





