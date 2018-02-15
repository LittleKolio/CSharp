namespace Defining_Classes_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_09_Rectangle_Intersection
    {
        public static void Main()
        {
            List<Rectangle> list = new List<Rectangle>();

            int[] input = Console.ReadLine()
                    .Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            for (int i = 0; i < input[0]; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                Rectangle rec = new Rectangle(
                    tokens[0],
                    long.Parse(tokens[1]),
                    long.Parse(tokens[2]),
                    long.Parse(tokens[3]),
                    long.Parse(tokens[4])
                    );
                list.Add(rec);
            }

            for (int i = 0; i < input[1]; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                Rectangle rec1 = list.First(r => r.Id == tokens[0]);
                Rectangle rec2 = list.First(r => r.Id == tokens[1]);
                bool result = rec1.Intersect(rec2);
                Console.WriteLine(result.ToString().ToLower());
            }
        }
    }
}
