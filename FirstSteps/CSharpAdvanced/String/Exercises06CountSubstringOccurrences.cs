using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Exercises06CountSubstringOccurrences
    {
        static void Main()
        {
            string text = Console.ReadLine();

            string strSequence = Console.ReadLine();

            int count = 0;
            int index = 0;
            while (true)
            {
                int found = text.IndexOf(
                    strSequence, 
                    index, 
                    text.Length - index, 
                    StringComparison.InvariantCultureIgnoreCase);

                if (found == -1) { break; }
                count++;
                index = found + 1;

                //Console.Write(found + " ");
            }

            Console.WriteLine(count);
        }
    }
}
