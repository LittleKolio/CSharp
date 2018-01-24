namespace Stacks_And_Queues_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_06_Truck_Tour
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Queue<long> petrol = new Queue<long>();
            Queue<long> distance = new Queue<long>();

            for (int i = 0; i < num; i++)
            {
                long[] nums = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

                petrol.Enqueue(nums[0]);
                distance.Enqueue(nums[1]);
            }

            int index;
            for (index = 0; index < num; index++)
            {
                long tank = 0;
                bool success = true;

                for (int i = 0; i < num; i++)
                {
                    long p = petrol.Peek();
                    long d = distance.Peek();

                    tank += (p - d);

                    if (tank < 0)
                    {
                        success = false;
                    }

                    //Console.WriteLine("Petrol: " + petrol.Peek());
                    //Console.WriteLine("Distance: " + distance.Peek());
                    //Console.WriteLine();

                    petrol.Enqueue(petrol.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                }

                if (success)
                {
                    break;
                }

                petrol.Enqueue(petrol.Dequeue());
                distance.Enqueue(distance.Dequeue());
            }

            Console.WriteLine(index);
        }
    }
}
