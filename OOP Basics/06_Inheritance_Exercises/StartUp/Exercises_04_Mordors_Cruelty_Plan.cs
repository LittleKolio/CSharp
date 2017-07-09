namespace Inheritance_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_04_Mordors_Cruelty_Plan
    {
        static void Main()
        {
            FoodFactory foodFactory = new FoodFactory();
            MoodFactory moodFactory = new MoodFactory();

            Gandalf gandalf = new Gandalf();

            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                gandalf.Eat(foodFactory.GetFood(item));
            }

            int points = gandalf.GetHappinessPoints();
            Mood mood = moodFactory.GetMood(points);

            Console.WriteLine(points);
            Console.WriteLine(mood);
        }
    }
}
