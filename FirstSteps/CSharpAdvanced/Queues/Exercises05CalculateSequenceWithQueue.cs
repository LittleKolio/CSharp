using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.WorkingWithQueues
{
    class Exercises05CalculateSequenceWithQueue
    {
        static void Main()
        {
            long num = long.Parse(Console.ReadLine());

            Queue<long> sequence = new Queue<long>();
            Queue<long> temp = new Queue<long>();
            sequence.Enqueue(num);
            temp.Enqueue(num);

            int next = 50;

            while (sequence.Count < 50)
            {
                long x = temp.Dequeue();
                sequence.Enqueue(x + 1);
                temp.Enqueue(x + 1);
                sequence.Enqueue(2 * x + 1);
                temp.Enqueue(2 * x + 1);
                sequence.Enqueue(x + 2);
                temp.Enqueue(x + 2);
            }

            Console.Write(sequence.Dequeue());
            for (int i = 1; i < next; i++)
            {
                Console.Write(" ");
                Console.Write(sequence.Dequeue());
            }
            Console.WriteLine();
        }
    }
}
