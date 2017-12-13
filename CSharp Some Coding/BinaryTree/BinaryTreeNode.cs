namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BinaryTreeNode<T>
    {
        private T value;
        private bool hasParent;
        private BinaryTreeNode<T> leftChild;
        private BinaryTreeNode<T> rightChild;

        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild, BinaryTreeNode<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public BinaryTreeNode(T value) 
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

        public BinaryTreeNode<T> LeftChild
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

        public BinaryTreeNode<T> RightChild
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

        //static void Main(string[] args)
        //{
        //}
    }
}
