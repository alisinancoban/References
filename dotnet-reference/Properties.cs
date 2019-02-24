using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop
{
    class Employee
    {
        private string empName;
        // Field data.
        public string EmpName
        {
                get { return empName; }
                set { if (value.Length > 10) { } else { empName = value; } }
        }
        public int EmpID { get; private set; }
        public float CurrPay { get; private set; } = 1000;
        public int WriteOnly { private get; set; }
        public int ReadOnly { get; private set; }

        // Constructors.
        public Employee() { }
        public Employee(int id) : this("yok", id) { }
        public Employee(string name, int id) : this(name, id, pay:0) { }
        public Employee(string name, int id, float pay)
        {
            EmpName = name;
            EmpID = id;
            CurrPay = pay;
        }
        // Methods.
        public void GiveBonus(float amount)
        {
            CurrPay += amount;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", EmpName);
            Console.WriteLine("ID: {0}", EmpID);
            Console.WriteLine("Pay: {0}", CurrPay);
        }
    }
}
