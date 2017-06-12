using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Lab
{
    class Lab_05_Concatenate_Strings
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
