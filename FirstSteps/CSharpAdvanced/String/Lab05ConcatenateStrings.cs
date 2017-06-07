using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Lab05ConcatenateStrings
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                text.Append(Console.ReadLine()).Append(" ");
            }

            Console.WriteLine(text);
        }
    }
}
