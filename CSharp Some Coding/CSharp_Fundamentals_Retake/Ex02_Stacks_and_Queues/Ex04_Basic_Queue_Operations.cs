namespace Trash.Ex02_Stacks_and_Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex04_Basic_Queue_Operations
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int inNum = input[0];
            int outNum = input[1];
            int checkNum = input[2];

            int[] arr = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(arr);

            int count = 0;
            while (count < outNum)
            {
                queue.Dequeue();
                count++;
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(checkNum))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
