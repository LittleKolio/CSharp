using System;
using System.Collections.Generic;

namespace Stacks_And_Queues_Lab
{
    class Lab_06_Math_Potato
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int pitch = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(input);
            int count = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < pitch - 1; i++)
                {
                    string name = queue.Dequeue();
                    queue.Enqueue(name);
                    //queue.Enqueue(queue.Dequeue());
                }
                if (PrimeTool.IsPrime(count))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                count++;
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }

    public static class PrimeTool
    {
        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        }
    }
}
