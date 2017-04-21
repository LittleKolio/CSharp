using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class RectangleWithStars
    {
        static void Main ()
        {
            int n = int.Parse(Console.ReadLine());

            int rowsIn = n % 2 == 0 ? (n - 1) : n;

            Console.WriteLine(new string('%', n * 2));

            for (int i = 1; i <= rowsIn; i++)
            {
                string row = "%";
                if (i == rowsIn / 2 + 1)
                {
                    row += new string(' ', n - 2);
                    row += "**";
                    row += new string(' ', n - 2);
                }
                else
                {
                    row += new string(' ', n * 2 - 2);
                }
                row += "%";

                Console.WriteLine(row);
                
            }

            Console.WriteLine(new string('%', n * 2));
        }
    }
}
