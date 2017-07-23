namespace Interfaces_And_Abstraction_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_05_Border_Control
    {
        static void Main()
        {
            List<ISociety> all = new List<ISociety>();

            string input;
            while (!(input = Console.ReadLine())
                .Equals("End"))
            {
                string[] tokens = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    all.Add(new Robot(tokens[0], tokens[1]));
                }
                else if (tokens.Length == 3)
                {
                    all.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else
                {
                    throw new Exception("Something is wrong");
                }
            }
            string digits = Console.ReadLine();
            CheckId(all, digits);
        }

        private static void CheckId(List<ISociety> all, string digits)
        {
            foreach (var item in all)
            {
                if (item.CheckId(digits))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
