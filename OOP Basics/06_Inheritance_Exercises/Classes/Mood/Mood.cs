namespace Inheritance_Exercises.Classes
{
    public abstract class Mood
    {
        public Mood(string type)
        {
            this.Type = type;
        }
        public string Type { get; set; }

        public override string ToString()
        {
            return this.Type;
        }
    }
}
