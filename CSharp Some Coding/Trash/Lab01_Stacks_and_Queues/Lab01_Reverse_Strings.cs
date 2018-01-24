namespace Trash
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab01_Reverse_Strings
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();

            Stack<char> stack = new Stack<char>(str.ToCharArray());

            //Stack<char> stack = new Stack<char>();
            //for (int i = 0; i < str.Length; i++)
            //{
            //    stack.Push(str[i]);
            //}

            Console.WriteLine(string.Join(" ", stack));

            //StringBuilder sb = new StringBuilder();
            //Console.WriteLine(sb.Append(stack.ToArray()));

            //StringBuilder sb = new StringBuilder();
            //while (stack.Count > 0)
            //{
            //    sb.Append(stack.Pop());
            //}
            //Console.WriteLine(sb);
        }
    }
}
