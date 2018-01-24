namespace Trash
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab05_Hot_Potato
    {
        public static void Main()
        {
            string[] str = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            int num = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(str);

            int count = 1;
            while (queue.Count > 1)
            {
                string child = queue.Dequeue();

                if (count == num)
                {
                    Console.WriteLine($"Removed {child}");
                    count = 1;
                }
                else
                {
                    queue.Enqueue(child);
                    count++;
                }

            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
