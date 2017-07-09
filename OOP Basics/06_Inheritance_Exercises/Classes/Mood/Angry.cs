namespace Inheritance_Exercises.Classes
{
    public class Angry : Mood
    {
        private const string Type = "Angry";
        public Angry() 
            : base(Type) { }
    }
}
