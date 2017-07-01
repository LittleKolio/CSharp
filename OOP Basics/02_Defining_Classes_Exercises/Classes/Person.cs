namespace Defining_Classes_Exercises.Classes
{
    class Person
    {
        public string name;
        public int age;

        public int Age
        {
            get { return this.age; }
        }
        public string Name
        {
            get { return this.name; }
        }

        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }
        public Person(int age)
        {
            this.name = "No name";
            this.age = age;
        }
        public Person(int age, string name)
        {
            this.name = name;
            this.age = age;
        }
    }
}