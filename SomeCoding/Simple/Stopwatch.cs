using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    class Stopwatch
    {
        static void Main()
        {

            var list = new List<string>();
            //var list = new HashSet<string>();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 10000000; i++)
            {
                list.Add(i.ToString());
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch = System.Diagnostics.Stopwatch.StartNew();

            list.Contains("56666665555");
            list.Remove("56666665555");

            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);

            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //watch.Stop();
            //Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
