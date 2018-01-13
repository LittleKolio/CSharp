namespace Matching_Brackets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            string expression = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char symbol = expression[i];
                if (symbol == '(')
                {
                    stack.Push(i);
                }
                else if (symbol == ')')
                {
                    int start = stack.Pop();
                    string str = expression.Substring(start, i - start + 1);
                    Console.WriteLine(str);
                }
            }
        }
    }
}
