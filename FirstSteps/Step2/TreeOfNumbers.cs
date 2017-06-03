using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step2
{
    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }
            this.value = value;
            children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public int ChildrednCount
        {
            get { return this.children.Count; }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException(
                    "The node already has a parent!");
            }

            child.hasParent = true;
            children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return children[index];
        }
    }

    public class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) 
            : this(value)
        {
            foreach (var child in children)
            {
                root.AddChild(child.root);
            }
        }

        public TreeNode<T> Root
        {
            get { return root; }
        }

        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (this.root == null) { return; }
            Console.WriteLine(spaces + root.Value);
            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrednCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + "  ");
            }
        }

        public void TraverseDFS()
        {
            PrintDFS(root, string.Empty);
        }
    }

    public static class TreeExample
    {
        static void Main()
        {
            Tree<int> tree =
                new Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6))
                );

            tree.TraverseDFS();
        }
    }
}
