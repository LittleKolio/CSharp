namespace Trash.Ex02_Stacks_and_Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex03_Maximum_Element
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();
            maxNumbers.Push(0);

            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                int[] query = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (query[0])
                {
                    case 1:
                        {
                            stack.Push(query[1]);
                            if (query[1] > maxNumbers.Peek())
                            {
                                maxNumbers.Push(query[1]);
                            }
                        }
                        break;
                    case 2:
                        {
                            if (stack.Pop() == maxNumbers.Peek())
                            {
                                maxNumbers.Pop();
                            }
                        }
                        break;
                    case 3: Console.WriteLine(maxNumbers.Peek()); break;
                    default:
                        break;
                }
            }
        }
    }
}
