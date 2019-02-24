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
            var std1 = new Student { Name = "Sinan" }; //Implicitly calling ctor

            var std2 = new Student() { Name = "Sinan", Id = 1036 }; //Explicitly calling ctor

            var std3 = new Student("Alper", 2) { Name = "Sinan", Id = 1036 }; //calling custom ctor

            var std4 = new Student(StudentType.Master) { Name = "Sinan", Id = 1036 };
        }

    }

    enum StudentType
    { Bachelor, Master, Erasmus }
    class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public StudentType StudentType { get; set;}

        public Student():this(StudentType.Bachelor){ }
        public Student(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public Student(StudentType studentType)
        {
            StudentType = studentType;
        }

        public void Display()
        {
            Console.WriteLine($"{Name}`s id {Id} Type: {StudentType}");
        }

    }
}

