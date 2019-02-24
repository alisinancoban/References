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
            unsafe
            {
                int myInt = 5;
                int * myPointer = &myInt;

                SquareIntPointer(myPointer);
                SquareIntPointer(&myInt);
                Console.WriteLine(myInt);
                Console.WriteLine((int)&myInt); //address of myInt

                Node n3 = new Node();
                Node n2 = new Node(2, n3);
                Node n1 = new Node(1,n2);
                
                Node* ptr = &n2;
                Console.WriteLine(ptr->Value + " " + ptr->Right->ToString() );
                Console.WriteLine((*ptr).Value + " " + (*(*ptr).Right).ToString());
                
            }
            //can`t work with pointer here
        }

        unsafe static void SquareIntPointer(int * ptr)
        {
            *ptr = *ptr * *ptr;
        }

        unsafe struct Node
        {
            public Node(int value, Node node)
            {
                Value = value;
                Right = &node;
            }
            public int Value;
            public Node* Right;

            public override string ToString()
            {
                return string.Format($"{Value}");
            }
        }
    }
}




