namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BinarySearchTreeNode<T> 
        : IComparable<BinarySearchTreeNode<T>>
        where T : IComparable<T>
    {
        private T value;
        private bool hasParent;
        private BinarySearchTreeNode<T> leftChild;
        private BinarySearchTreeNode<T> rightChild;

        public BinarySearchTreeNode(T value, BinarySearchTreeNode<T> leftChild, BinarySearchTreeNode<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public BinarySearchTreeNode(T value) 
            : this (value, null, null)
        { }

        public T Value
        {
            get { return this.value; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        "Cannot insert null value!");
                }
                this.value = value;
            }
        }

        public BinarySearchTreeNode<T> LeftChild
        {
            get { return this.leftChild; }
            set
            {
                if (value == null)
                {
                    return;
                }

                if (value.hasParent)
                {
                    throw new ArgumentException(
                        "The node already has a parent!");
                }

                value.hasParent = true;
                this.leftChild = value;
            }
        }

        public BinarySearchTreeNode<T> RightChild
        {
            get { return this.rightChild; }
            set
            {
                if (value == null)
                {
                    return;
                }

                if (value.hasParent)
                {
                    throw new ArgumentException(
                        "The node already has a parent!");
                }

                value.hasParent = true;
                this.rightChild = value;
            }
        }

        public int CompareTo(BinarySearchTreeNode<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
