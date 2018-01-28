namespace Trash.Ex02_Stacks_and_Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex09_Stack_Fibonacci
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            input++;

            Stack<long> stackFib = new Stack<long>(input + 1);
            stackFib.Push(0);
            stackFib.Push(1);

            while (stackFib.Count < input)
            {
                long a = stackFib.Pop();
                long b = stackFib.Peek();

                stackFib.Push(a);

                if (stackFib.Count < input)
                {
                    stackFib.Push(a + b);
                }
            }

        }
    }
}
