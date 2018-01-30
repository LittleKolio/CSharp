namespace Simple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StringPalindrome
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(CreatePalindrome(num, 'a'));
            Console.ReadKey();
        }

        private static string CreatePalindrome(int length, int start)
        {
            StringBuilder result = new StringBuilder();

            int indexRev = length / 2 + length % 2;

            int increment = 1;

            for (int i = 0;
                i < length && i >= 0;
                i += increment)
            {
                if (i >= indexRev)
                {
                    if (length % 2 != 0)
                    {
                        i -= increment;
                    }
                    increment *= -1;
                    continue;
                }

                char str = Convert.ToChar(start + i);
                result.Append(str);
            }

            return result.ToString();
        }
    }
}
