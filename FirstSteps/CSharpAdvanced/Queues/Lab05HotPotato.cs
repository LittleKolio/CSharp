using System;
using System.Collections.Generic;

namespace CSharpAdvanced.WorkingWithQueues
{
    class Lab05HotPotato
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int pitch = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(input);
            while (queue.Count > 1)
            {
                for (int i = 0; i < pitch - 1; i++)
                {
                    string name = queue.Dequeue();
                    queue.Enqueue(name);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
