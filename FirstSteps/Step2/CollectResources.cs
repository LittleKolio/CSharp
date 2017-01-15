using System;
using System.Collections.Generic;

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

                int quan = TryGetResource(start);
                int currIndex = (start + end) % collection.Length;

                while (!visited[currIndex])
                {
                    quan += TryGetResource(currIndex);
                    currIndex = (currIndex + end) % collection.Length;
                }

                if (quan > quantity)
                {
                    quantity = quan;
                }
            }

            Console.WriteLine(quantity);
        }

        private static int TryGetResource(int index)
        {
            string[] res = collection[index].Split('_');
            if (resources.Contains(res[0]))
            {
                visited[index] = true;
                return res.Length > 1 ? int.Parse(res[1]) : 1;
            }
            return 0;
        }
    }
}
