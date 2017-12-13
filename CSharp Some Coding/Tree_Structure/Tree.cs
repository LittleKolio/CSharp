namespace TreeStructure
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
            CreateRoot(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        public TreeNode<T> Root
        {
            get { return this.root; }
        }

        public void CreateRoot(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value");
            }

            this.root = new TreeNode<T>(value);
        }

        private void Print(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                Print(child, spaces + "  ");
            }
        }

        public void Traverse()
        {
            this.Print(this.root, string.Empty);
        }
    }
}
