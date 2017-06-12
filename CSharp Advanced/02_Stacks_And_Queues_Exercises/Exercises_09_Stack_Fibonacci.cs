using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_And_Queues_Exercises
{
    class Exercises_09_Stack_Fibonacci
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            /*
            Queue<long> fibQueue = new Queue<long>();
            fibQueue.Enqueue(0);
            fibQueue.Enqueue(1);

            for (int i = 0; i < input; i++)
            {
                fibQueue.Enqueue(fibQueue.Dequeue() + fibQueue.Peek());
            }
            //fibNumbers.Dequeue();
            Console.WriteLine(fibQueue.Peek());
            */

            Stack<long> fibStack = new Stack<long>();
            fibStack.Push(0);
            fibStack.Push(1);

            for (int i = 0; i < input - 1; i++)
            {
                long a = fibStack.Pop();
                long b = fibStack.Peek();
                fibStack.Push(a);
                fibStack.Push(a + b);
            }
            Console.WriteLine(fibStack.Peek());
        }
    }
}
