namespace OOP_Intro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_01_Define_class_Person
    {
        static void Main()
        {
            Person1 per1 = new Person1();
            per1.Name = "Pesho";
            per1.Age = 20;
            Print(per1.Name, per1.Age);

            Person1 per11 = new Person1() { Name = "Gosho", Age = 18 };
            Print(per11.Name, per11.Age);

            Person2 per2 = new Person2("Stamat", 43);
            Print(per2.Name, per2.Age);

            Person3 per3 = new Person3();
            Print(per3.Name, per3.Age);

        }

        static void Print(string name, int age)
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"age: {age}");
            Console.WriteLine();
        }
    }

    public class Person1
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person2(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }

    public class Person3
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person3(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person3() : this("Carvul", 44) { }
    }

    public class Person4
    {
        private string name;
        private int age;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0) { throw new InvalidArgumentException(); }
                this.age = value;
            }
        }

        public Person4(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person4() : this("Carvul", 44) { }
    }
}
