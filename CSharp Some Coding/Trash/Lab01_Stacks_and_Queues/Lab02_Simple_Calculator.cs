namespace Trash
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab02_Simple_Calculator
    {
        public static void Main()
        {
            string[] str = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new Stack<string>(str.Reverse());
            while (stack.Count > 1)
            {
                int num1 = int.Parse(stack.Pop());
                string op = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                switch (op)
                {
                    case "+": stack.Push((num1 + num2).ToString()); break;
                    case "-": stack.Push((num1 - num2).ToString()); break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
