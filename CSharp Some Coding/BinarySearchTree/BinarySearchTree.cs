namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BinarySearchTree<T>
        where T : IComparable<T>
    {
        public class BinaryTreeNode<T>
            : IComparable<BinaryTreeNode<T>>
            where T : IComparable<T>
        {
            private T value;
            private BinaryTreeNode<T> parent;
            private BinaryTreeNode<T> leftChild;
            private BinaryTreeNode<T> rightChild;

            public BinaryTreeNode(T value)
            {
                this.value = value;
                this.leftChild = null;
                this.rightChild = null;
                this.parent = null;
            }

            public override string ToString()
            {
                return this.value.ToString();
            }

            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
                return this.CompareTo(other) == 0;
            }

            public int CompareTo(BinaryTreeNode<T> other)
            {
                return this.value.CompareTo(other.value);
            }

        }

        private BinaryTreeNode<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }
    }
}
