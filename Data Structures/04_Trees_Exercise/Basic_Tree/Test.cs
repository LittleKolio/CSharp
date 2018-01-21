namespace Basic_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            ReadTree(num);

            int rootValue = GetRootNode().Value;

            Console.WriteLine($"Root node: {rootValue}");
        }

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];
        }

        static void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = GetTreeNodeByValue(parent);
            Tree<int> childNode = GetTreeNodeByValue(child);

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        static void ReadTree(int num)
        {
            for (int i = 0; i < num - 1; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                AddEdge(input[0], input[1]);
            }
        }

        static Tree<int> GetRootNode()
        {
            return nodeByValue.Values
                .FirstOrDefault(n => n.Parent == null);
        }
    }
}
