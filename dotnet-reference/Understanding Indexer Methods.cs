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
            PersonCollectionList myPeople = new PersonCollectionList();

            //indexer operator ile yeni person 
            //nesneleri ekleyebiliyor olmaliyiz 
            myPeople.Add(new Person("Alper", "Coban", 21));
            myPeople.Add(new Person("Mustafa", "Coban", 50));

            myPeople[0] = new Person("Ali Sinan", "Coban", 23);

            //for ile index üzerinden gezebiliyor olmaliyiz
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine(myPeople[i]);
            }

            Console.ReadLine();
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public override string ToString()
        {
            return string.Format("Name: {0} Surname: {1} Age: {2}"
                , Name, Surname, Age);
        }
    }
    public interface PersonContainer
    {
        Person this[int index] { get; set; }
    }
    public class PersonCollectionList : IEnumerable, PersonContainer
    {
        private List<Person> listPeople = new List<Person>();

        //ÖNEMLÝ!! bu sayede PersonCollection'ý
        //index operatoru [] ile kullanabilecegiz
        public Person this[int index]
        {
            get { return (Person)listPeople[index]; }
            set { listPeople.Insert(index, value); }
        }

        public int Count { get { return listPeople.Count; } }

        public IEnumerator GetEnumerator()
        {
            return listPeople.GetEnumerator();
        }

        internal void Add(Person person) { listPeople.Add(person); }
    }
    public class PersonCollectionDict : IEnumerable
    {
        private Dictionary<string, Person> dictPeople = new Dictionary<string, Person>();

        //ÖNEMLÝ!! bu sayede PersonCollection'ý
        //index operatoru [] ile kullanabilecegiz
        public Person this[string name]
        {
            get { return (Person)dictPeople[name]; }
            set { dictPeople[name] = value ; }
        }

        public int Count { get { return dictPeople.Count; } }

        public IEnumerator GetEnumerator()
        {
            return dictPeople.GetEnumerator();
        }

        internal void Add(Person person) { dictPeople[person.Name] = person; }
    }


}




