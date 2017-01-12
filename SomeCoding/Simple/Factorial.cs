using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    class Factorial
    {
        static void Main()
        {
            #region n!
            /*
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            decimal factorial = 1;
            while (true)
            {
                if (n <= 1)
                {
                    break;
                }
                factorial *= n;
                n--;
            }
            Console.WriteLine("n! = " + factorial);
            */
            #endregion

            #region [n...m]!
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            int m = int.Parse(Console.ReadLine());

            int numSmall = Math.Min(n, m);
            int numBig = Math.Max(n, m);

            int numChange = numSmall;
            long product = 1;

            while (true)
            {
                if (numChange > numBig)
                {
                    break;
                }
                product *= numChange;
                numChange++;
            }
            

            Console.WriteLine("product[{0}...{1}] = {2}", numSmall, numBig, product);
            #endregion
        }
    }
}
