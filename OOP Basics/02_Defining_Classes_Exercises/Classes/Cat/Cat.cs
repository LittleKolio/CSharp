namespace Defining_Classes_Exercises.Classes
{
    class Cat
    {
        private string name;
        public Cat(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return this.name; }
        }
    }
}
