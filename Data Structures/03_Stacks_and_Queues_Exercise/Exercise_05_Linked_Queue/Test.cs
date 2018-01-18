namespace Exercise_05_Linked_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        public static void Main(string[] args)
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            int first = queue.Dequeue();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            queue.Enqueue(-7);
            queue.Enqueue(-8);
            queue.Enqueue(-9);
            Console.WriteLine("Count = {0}", queue.Count);
            Console.WriteLine(string.Join(", ", queue.ToArray()));
            Console.WriteLine("---------------------------");

            //first = queue.Dequeue();
            //Console.WriteLine("First = {0}", first);
            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //queue.Enqueue(-10);
            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");

            //first = queue.Dequeue();
            //Console.WriteLine("First = {0}", first);
            //Console.WriteLine("Count = {0}", queue.Count);
            //Console.WriteLine(string.Join(", ", queue.ToArray()));
            //Console.WriteLine("---------------------------");
        }

    }
}
