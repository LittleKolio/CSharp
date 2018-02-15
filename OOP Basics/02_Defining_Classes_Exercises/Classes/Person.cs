namespace Defining_Classes_Exercises.Classes
{
    class Person
    {
        private int age;
        private string name;

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
        public Person()
            : this(1, "No name")
        {
        }

        public Person(int age)
            : this(age, "No name")
        {
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }
}