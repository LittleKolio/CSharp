namespace Inheritance_Exercises.Classes
{
    public class Happy : Mood
    {
        private const string Type = "Happy";
        public Happy() 
            : base(Type) { }
    }
}
