using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Sets
{
    class Exercises03PeriodicTable
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            // SortedSet it is slower
            // SortedSet<string> elements = new SortedSet<string>();
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string[] tempArr = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                elements.UnionWith(tempArr);
            }

            Console.WriteLine(string.Join(
                " ", elements.OrderBy(e => e)));
        }
    }
}
