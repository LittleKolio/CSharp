namespace Exercises_02_Sort_Words
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
            List<string> words = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            words.Sort();
            foreach (string item in words)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
