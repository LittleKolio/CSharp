namespace Trash
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab04_Matching_Brackets
    {
        public static void Main()
        {
            string str = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < str.Length; i++)
            {
                char element = str[i];
                if (element == '(')
                {
                    stack.Push(i);
                }
                else if (element == ')')
                {
                    int start = stack.Pop();
                    string result = str.Substring(start, i - start + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
