namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;

        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            BinaryTreeNode<T> leftChildNode
                = leftChild != null
                ? leftChild.root
                : null;

            BinaryTreeNode<T> rightChildNode
                = rightChild != null
                ? rightChild.root
                : null;

            this.root = new BinaryTreeNode<T>(value, leftChildNode, rightChildNode);
        }

        public BinaryTree(T value)
            : this (value, null, null)
        { }

        public BinaryTreeNode<T> Root
        {
            get { return this.root; }
        }

        private void Print(BinaryTreeNode<T> root)
        {
            if (root == null) { return; }

            Print(root.LeftChild);
            Console.Write(root.Value + "   ");
            Print(root.RightChild);
        }

        public void Print()
        {
            Print(this.Root);
            Console.WriteLine();
        }
    }
}
