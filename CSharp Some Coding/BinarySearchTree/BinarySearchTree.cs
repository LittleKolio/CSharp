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
        private class BinaryTreeNode<T>
            : IComparable<BinaryTreeNode<T>>
            where T : IComparable<T>
        {
            internal T value;
            internal BinaryTreeNode<T> parent;
            internal BinaryTreeNode<T> leftChild;
            internal BinaryTreeNode<T> rightChild;

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

        public void Insert(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }
            this.root = Insert(value, null, this.root);
        }

        private BinaryTreeNode<T> Insert(T value, 
            BinaryTreeNode<T> parentNode, 
            BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<T>(value);
                node.parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.value);
                if (compareTo < 0)
                {
                    node.leftChild = Insert(value, node, node.leftChild);
                }
                else if (compareTo > 0)
                {
                    node.rightChild = Insert(value, node, node.rightChild);
                }
            }

            return node;
        }

        private BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = this.root;

            while (node != null)
            {
                int compareTo = value.CompareTo(node.value);
                if (compareTo < 0)
                {
                    node = node.leftChild;
                }
                else if (compareTo > 0)
                {
                    node = node.rightChild;
                }
            }
            
            return node;
        }

        public void Remove(T value)
        {
            BinaryTreeNode<T> nodeToDelete = Find(value);

            if (nodeToDelete == null) { return; }

            Remove(nodeToDelete);
        }

        private void Remove(BinaryTreeNode<T> node)
        {
            if (node.leftChild != null && node.rightChild != null)
            {
                BinaryTreeNode<T> replacement = node.rightChild;
                while (replacement.leftChild != null)
                {
                    replacement = replacement.leftChild;
                }
                node.value = replacement.value;
                node = replacement;
            }

            BinaryTreeNode<T> theChild
                = node.leftChild != null
                ? node.leftChild
                : node.rightChild;

            if (theChild != null)
            {

            }

            throw new NotImplementedException();
        }
    }
}
