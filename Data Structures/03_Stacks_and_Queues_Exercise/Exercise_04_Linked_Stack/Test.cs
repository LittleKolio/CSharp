namespace Exercise_04_Linked_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        public static void Main()
        {
            LinkedStack<int> stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            int last = stack.Pop();
            Console.WriteLine("First = {0}", last);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            stack.Push(-7);
            stack.Push(-8);
            stack.Push(-9);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");
        }
    }
}
