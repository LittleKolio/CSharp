namespace Polymorphism_Exercises.Classes
{
    public abstract class FoodFactory
    {
        public static Food GetFood(string[] foodInput)
        {
            switch (foodInput[0])
            {
                case "Vegetable":
                    return new Vegetable(int.Parse(foodInput[1]));
                case "Meat":
                    return new Meat(int.Parse(foodInput[1]));
                default: return null;
            }
        }
    }
}
