namespace Defining_Classes_Exercises.Classes
{
    class Cargo
    {
        private int weight;
        private string type;
        public Cargo(int weight, string type)
        {
            this.weight = weight;
            this.type = type;
        }
        public string Type
        {
            get { return this.type; }
        }
    }
}
