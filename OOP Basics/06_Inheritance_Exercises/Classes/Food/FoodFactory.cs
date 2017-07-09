namespace Inheritance_Exercises.Classes
{
    public class FoodFactory
    {
        public Food GetFood(string foodType)
        {
            switch (foodType.ToLower())
            {
                case "cram": return new Cram();
                case "lembas": return new Lembas();
                case "apple": return new Apple();
                case "melon": return new Melon();
                case "honeycake": return new HoneyCake();
                case "mushrooms": return new Mushrooms();
                default: return new OtherFood();
            }
        }
    }
}
