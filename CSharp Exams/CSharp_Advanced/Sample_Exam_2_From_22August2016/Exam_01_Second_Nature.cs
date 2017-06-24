using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_2_From_22August2016
{
    /// <summary>
    /// You will be given a sequence of integers - each indicating the Weiss dust in each flower.
    /// After that you will be given another sequence of integers - a bucket and the water in it.
    /// Watering is done by picking last received bucket (one) and start watering from the first entered flower.
    /// You give the first entered flower N water, reducing its Weiss dust by N.
    /// When flower's integer value reaches 0 or less, it blooms and gets removed.
    /// If the current flower's value is greater than the current bucket's value pick buckets until you reduce its integer value to 0 or less.
    /// If a bucket's value is greater than the flower's current value, you water the flower, and add the remaining water to the next bucket in order.
    /// In case there is no next bucket, keep the remaining water in the same bucket.
    /// If the current bucket's value is equal to the current flower's value, the flower develops a second nature. 
    /// </summary>
    /// <output>
    /// If you have managed to water all the flowers, print the remaining water buckets, from the last entered - to the first.
    /// If you haven't managed to water all the flowers with the given water, you must print the remaining flowers, by order of entrance - from the first entered - to the last.
    /// You must also print the second nature flowers, by order of their appearance.
    /// If there are no second nature flowers, just print "None".
    /// </output>
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
