namespace Exercise_04_Froggy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static void Main()
        {
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();

            string[] input = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                bool isEven = (i + 1) % 2 == 0;
                if (isEven)
                {
                    stack.Push(input[i]);
                }
                else
                {
                    queue.Enqueue(input[i]);
                }
            }

            string[] result = queue.ToArray().Concat(stack.ToArray()).ToArray();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
