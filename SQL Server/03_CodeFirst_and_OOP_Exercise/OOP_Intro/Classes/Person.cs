using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Intro
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get; set; }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0) { throw new InvalidArgumentException(); }
                this.age = value;
            }
        }
        
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person() : this("No name", 1) { }

        public Person(int age) : this("No name", age) { }

        public Person(string name) : this(name, 1) { }
    }
}
