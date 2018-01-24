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

            //Ex01RootNode();

            //Ex02PrintTree();

            //Ex03LeafNodes();

            //Ex04MiddleNodes();
        }

        private static void Ex04MiddleNodes()
        {
            List<int> list = MiddleNodes(GetRootNode());

            Console.Write("Middle nodes: ");
            Console.WriteLine(string.Join(" ", list.OrderBy(n => n)));
        }

        private static void Ex01RootNode()
        {
            int rootValue = GetRootNode().Value;
            Console.WriteLine($"Root node: {rootValue}");
        }

        private static void Ex02PrintTree()
        {
            PrintTree(GetRootNode());
        }

        private static void Ex03LeafNodes()
        {
            List<int> list = new List<int>();
            LeafNodes(GetRootNode(), list);

            Console.Write("Leaf nodes: ");
            Console.WriteLine(string.Join(" ", list.OrderBy(n => n)));
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

        static void PrintTree(Tree<int> node, int indent = 0)
        {
            Console.WriteLine(new string(' ', indent) + node.Value);
            foreach (Tree<int> item in node.Children)
            {
                PrintTree(item, indent + 1);
            }
        }

        static void LeafNodes(Tree<int> node, List<int> list)
        {
            if (node.Children.Count == 0)
            {
                list.Add(node.Value);
            }

            foreach (Tree<int> item in node.Children)
            {
                LeafNodes(item, list);
            }
        }

        static List<int> MiddleNodes(Tree<int> node)
        {
            Queue<Tree<int>> queue = 
                new Queue<Tree<int>>(node.Children);

            List<int> list = new List<int>();

            while (queue.Count != 0)
            {
                Tree<int> current = queue.Dequeue();
                if (current.Children.Count != 0 &&
                    current.Parent != null)
                {
                    list.Add(current.Value);

                    foreach (Tree<int> item in current.Children)
                    {
                        queue.Enqueue(item);
                    }
                }
            }

            return list;
        }

        static void PrintMiddleNodes()
        {
            List<int> list = nodeByValue.Values
                .Where(x => x.Parent != null && x.Children.Count != 0)
                .Select(x => x.Value)
                .OrderBy(x => x)
                .ToList();

            Console.Write("Middle nodes: " + string.Join(" ", list));
        }
    }
}
