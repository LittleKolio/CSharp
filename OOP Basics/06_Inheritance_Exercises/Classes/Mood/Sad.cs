namespace Inheritance_Exercises.Classes
{
    public class Sad : Mood
    {
        private const string Type = "Sad";
        public Sad() 
            : base(Type) { }
    }
}
