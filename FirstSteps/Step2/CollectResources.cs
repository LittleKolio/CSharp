using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step2
{
    class CollectResources
    {
        private static ISet<string> resources = new HashSet<string>()
        {
            "stone", "gold", "wood", "food"
        };
        private static bool[] visited;
        private static string[] collection;

        static void Main()
        {
            collection = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            int quantity = 0;

            for (int i = 1; i <= n; i++)
            {
                visited = new bool[collection.Length];
                string[] path = Console.ReadLine().Split();
                int start = int.Parse(path[0]);
                int end = int.Parse(path[1]);
            }
        }
    }
}
