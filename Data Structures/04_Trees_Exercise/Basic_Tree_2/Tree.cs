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
    }
}
