using System;
using System.Collections.Generic;

namespace Step2
{
    public class BinaryTreeNode<T>
    {
        private T value;
        private bool hasParent;
        private BinaryTreeNode<T> leftChild;
        private BinaryTreeNode<T> rightChild;

        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild, 
            BinaryTreeNode<T> rightChild)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }
            this.value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
        public BinaryTreeNode(T value)
            : this(value, null, null)
        {
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public BinaryTreeNode<T> LeftChild
        {
            get { return this.leftChild; }
            set
            {
                if (value == null) { return; }
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
                if (value == null) { return; }
                if (value.hasParent)
                {
                    throw new ArgumentException(
                        "The node already has a parent!");
                }
                value.hasParent = true;
                this.rightChild = value;
            }
        }
    }

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;
        public BinaryTree(T value, BinaryTree<T> leftChild, 
            BinaryTree<T> rightChild)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            BinaryTreeNode<T> leftChildNode = leftChild != null 
                ? leftChild.root 
                : null;
            BinaryTreeNode<T> rightChildNode = rightChild != null
                ? rightChild.root
                : null;
            this.root = new BinaryTreeNode<T>(value, leftChildNode, rightChildNode);
        }

        public BinaryTree(T value)
            : this(value, null, null)
        {
        }

        public BinaryTreeNode<T> Root
        {
            get { return this.root; }
        }

        private void PrintInorder(BinaryTreeNode<T> root)
        {
            if (root == null) { return; }

            PrintInorder(root.LeftChild);
            Console.Write(root.Value + " ");
            PrintInorder(root.RightChild);
        }

        public void PrintInorder()
        {
            PrintInorder(this.root);
            Console.WriteLine();
        }
    }

    public class BinaryTreeExample
    {
        public static void Main()
        {
            BinaryTree<int> binaryTree =
                new BinaryTree<int>(14,
                    new BinaryTree<int>(19,
                        new BinaryTree<int>(23),
                        new BinaryTree<int>(6,
                            new BinaryTree<int>(10),
                            new BinaryTree<int>(21))),
                    new BinaryTree<int>(15,
                        new BinaryTree<int>(3),
                        null));

            binaryTree.PrintInorder();
        }
    }
}
