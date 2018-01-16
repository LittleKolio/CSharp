namespace Exercise_01_Reverse_Numbers_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input != string.Empty)
            {
                Stack<int> stack = new Stack<int>(
                    input.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                while (stack.Count > 0)
                {
                    Console.Write(stack.Pop() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
