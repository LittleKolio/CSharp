﻿namespace Stacks_And_Queues_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_05_Calculate_Sequence_With_Queue
    {
        public static void Main()
        {
            Queue<long> queue = new Queue<long>();
            List<long> list = new List<long>();

            long num = long.Parse(Console.ReadLine());

            queue.Enqueue(num);

            long current = default(long);
            int count = 0;
            while (count < 50 / 3)
            {
                current = queue.Dequeue();
                list.Add(current);

                queue.Enqueue(current + 1);
                queue.Enqueue(current * 2 + 1);
                queue.Enqueue(current + 2);

                count++;
            }

            current = queue.Dequeue();
            list.Add(current);
            queue.Enqueue(current + 1);

            list.AddRange(queue);

            //Console.WriteLine(list.Count);

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
