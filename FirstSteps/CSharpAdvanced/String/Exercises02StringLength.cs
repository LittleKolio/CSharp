using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Exercises02StringLength
    {
        static void Main()
        {
            int length = 20;

            string text = Console.ReadLine();

            if (text.Length >= length)
            {
                Console.WriteLine(text.Substring(0, length));
            }
            else
            {
                Console.WriteLine(text.PadRight(20, '*'));
            }
        }
    }
}
