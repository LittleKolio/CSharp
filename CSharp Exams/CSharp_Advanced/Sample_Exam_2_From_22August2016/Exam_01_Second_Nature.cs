using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_2_From_22August2016
{
    class Exam_01_Second_Nature
    {
        static void Main()
        {
            Stack<int> flowers = new Stack<int>(
                Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                );

            Stack<int> water = new Stack<int>(
                Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                );

            Queue<int> list = new Queue<int>();

            while (flowers.Count > 0 && water.Count > 0)
            {
                int tempW = water.Pop();
                int tempF = flowers.Pop();

                int result = tempF - tempW;

                if (result == 0)
                {
                    list.Enqueue(tempF);
                }
                else if (result < 0)
                {
                    if (water.Count > 0)
                    {
                        water.Push(water.Pop() + Math.Abs(result));
                    }
                    else
                    {
                        water.Push(result);
                    }
                }
                else if (result > 0)
                {
                    flowers.Push(result);
                }
            }

            if (water.Count > 0)
            {
                Console.WriteLine(string.Join(" ", water));
            }
            else if (flowers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", flowers));
            }

            if (list.Count > 0)
            {
                Console.WriteLine(string.Join(" ", list));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
