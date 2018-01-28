namespace Stacks_And_Queues_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_11_Poisonous_Plants
    {
        public static void Main()
        {

            int num = int.Parse(Console.ReadLine());

            long[] input = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            //Console.WriteLine(string.Join(" ", input));

            int day = 0;
            while (true)
            {
                bool plantDied = false;
                for (int i = input.Length - 1; i > 0; i--)
                {
                    if (input[i] == -1)
                    {
                        continue;
                    }

                    int index = 1;
                    while (input[i - index] == -1)
                    {
                        index++;
                    }

                    if (input[i - index] < input[i])
                    {
                        input[i] = -1;
                        plantDied = true;
                    }
                }

                if (!plantDied)
                {
                    break;
                }

                day++;
            }
            //Console.WriteLine(string.Join(" ", input));

            //Console.WriteLine(string.Join(" ", queue.ToArray().Reverse()));

            Console.WriteLine(day);
        }
    }
}
