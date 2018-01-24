namespace Stacks_And_Queues_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Lab_01_Reverse_Strings
    {
        public static void Main()
        {
            string str = Console.ReadLine();

            string revStr = ReverseStringStack(str);
            //string revStr = ReverseStringDirect(str);
            //string revStr = ReverseString(str);

            Console.WriteLine(revStr);
        }

        public static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public static string ReverseStringDirect(string s)
        {
            char[] array = new char[s.Length];
            int forward = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                array[forward++] = s[i];
            }
            return new string(array);
        }

        public static string ReverseStringStack(string s)
        {
            //Stack<char> stack = new Stack<char>();
            //for (int i = 0; i < s.Length; i++)
            //{
            //    stack.Push(s[i]);
            //}

            Stack<char> stack = new Stack<char>(s.ToCharArray());

            //StringBuilder sb = new StringBuilder();
            //sb.Append(stack.ToArray());

            return string.Join("", stack);
        }
    }
}
