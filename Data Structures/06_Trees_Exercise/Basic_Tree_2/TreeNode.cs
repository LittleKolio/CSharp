namespace Basic_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get { return this.value; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        "Value is null!");
                }
                this.value = value;
            }
        }

        public List<TreeNode<T>> Children
        {
            get { return this.children; }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(
                    "Child is null!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException(
                    "Already has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }


    }
}
