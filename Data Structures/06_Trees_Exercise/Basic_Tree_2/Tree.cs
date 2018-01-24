namespace Basic_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Value is null!");
            }
            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this (value)
        {
            foreach (Tree<T> item in children)
            {
                this.root.AddChild(item.root);
            }
        }

        public TreeNode<T> Root
        {
            get { return this.root; }
        }

        private void PrintDFS(TreeNode<T> node, int indent = 0)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(new string(' ', indent) + node.Value);
            foreach (TreeNode<T> item in node.Children)
            {
                this.PrintDFS(item, indent = 2);
            }
        }

        public void TraverseDFS()
        {
            this.PrintDFS(this.root);
        }

        //public TreeNode<T> FindToFill_BFS(T value)
        //{
        //    Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        //    queue.Enqueue(this.root);
        //    TreeNode<T> node = null;
        //    while (queue.Count > 0)
        //    {
        //        node = queue.Dequeue();
        //        if (value.Equals(node.Value))
        //        {
        //            break;
        //        }

        //        foreach (TreeNode<T> child in node.Children)
        //        {
        //            queue.Enqueue(child);
        //        }
        //    }

        //    return node;
        //}
    }
}
