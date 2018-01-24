namespace Basic_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        static Tree<int> tree;
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            ReadTree();


        }

        static void ReadTree()
        {
            int[] input = SplitInput(Console.ReadLine(), " ");

            tree = new Tree<int>(input[0]);

            TreeNode<int> child = new TreeNode<int>(input[0]);
            tree.Root.AddChild(child);

            ReadTree(tree.Root);
        }

        static int[] SplitInput(string str, string delimiter)
        {
            return str.Split(delimiter.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
        //static void ReadTree(int num)
        //{
        //    for (int i = 0; i < num - 1; i++)
        //    {
        //        int[] input = Console.ReadLine()
        //            .Split(new char[] { ' ' },
        //                StringSplitOptions.RemoveEmptyEntries)
        //            .Select(int.Parse)
        //            .ToArray();

        //        AddTree(input[0], input[1]);
        //    }
        //}

        static void AddTree(int rootVal, int childVal)
        {
            if (tree == null)
            {
                tree = new Tree<int>(rootVal);
            }
            else
            {
                TreeNode<int> root = tree.FindToFill_BFS(rootVal);
            }
            TreeNode<int> child = GetTreeNodeByValue(childVal);

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }

        static TreeNode<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];
        }
    }
}
