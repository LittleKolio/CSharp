using System;
using System.Collections.Generic;

//https://visualgo.net/en

public class BinarySearchTree<T>
    where T : IComparable<T>
{
    private class Node
    {
        public T Value { get; private set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.LeftNode = null;
            this.RightNode = null;
        }
    }

    private Node root;

    public BinarySearchTree()
    {
        this.root = null;
    }

    /*
    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
            return;
        }

        Node parent = null;
        Node current = this.root;
        while (current != null)
        {
            int compare = current.Value.CompareTo(value);
            if (compare > 0)
            {
                parent = current;
                current = current.LeftNode;
            }
            else if (compare < 0)
            {
                parent = current;
                current = current.RightNode;
            }
            else if (compare == 0)
            {
                return;
            }
        }

        Node node = new Node(value);
        if (parent.Value.CompareTo(value) > 0)
        {
            parent.LeftNode = node;
        }
        else
        {
            parent.RightNode = node;
        }
    }
    */

    //*
    public void Insert(T value)
    {
        this.root = this.Insert(this.root, value);
    }

    private Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        int compare = node.Value.CompareTo(value);

        if (compare > 0)
        {
            node.LeftNode = this.Insert(node.LeftNode, value);
        }
        else if (compare < 0)
        {
            node.RightNode = this.Insert(node.RightNode, value);
        }

        return node;
    }
    //*/

    public bool Contains(T value)
    {
        Node current = this.root;
        while (current != null)
        {
            int compare = current.Value.CompareTo(value);
            if (compare > 0)
            {
                current = current.LeftNode;
            }
            else if (compare < 0)
            {
                current = current.RightNode;
            }
            else if (compare == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        if (this.root.LeftNode == null &&
            this.root.RightNode == null)
        {
            this.root = null;
            return;
        }

        Node parent = null;
        Node current = this.root;
        while (current.LeftNode != null)
        {
            parent = current;
            current = current.LeftNode;
        }

        if (current.RightNode != null)
        {
            parent.LeftNode = current.RightNode;
            current.RightNode = null;
        }
        else
        {
            parent.LeftNode = null;
        }

    }

    public BinarySearchTree<T> Search(T item)
    {
        BinarySearchTree<T> tree = new BinarySearchTree<T>();
        Node current = this.root;
        while (current != null)
        {
            int compare = current.Value.CompareTo(item);
            if (compare > 0)
            {
                current = current.LeftNode;
            }
            else if (compare < 0)
            {
                current = current.RightNode;
            }
            else if (compare == 0)
            {
                tree.Copy(current);
                return tree;
            }
        }

        return null;
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.LeftNode);
        this.Copy(node.RightNode);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        List<T> list = new List<T>();
        this.Range(this.root, list, startRange, endRange);
        return list;
    }

    private void Range(Node node, List<T> list, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        this.Range(node.LeftNode, list, startRange, endRange);

        if (node.Value.CompareTo(startRange) >= 0 &&
            node.Value.CompareTo(endRange) <= 0)
        {
            list.Add(node.Value);
        }

        this.Range(node.RightNode, list, startRange, endRange);

    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.LeftNode, action);
        action(node.Value);
        this.EachInOrder(node.RightNode, action);
    }
}



public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.Insert(20);
        tree.Insert(15);
        tree.Insert(78);
        tree.Insert(78);
        tree.Insert(5);
        tree.Insert(77);
        tree.Insert(163);

        tree.EachInOrder(Console.WriteLine);
        Console.WriteLine();

        BinarySearchTree<int> newTree = tree.Search(78);
        newTree.Insert(66);

        tree.EachInOrder(Console.WriteLine);
        Console.WriteLine();

        newTree.EachInOrder(Console.WriteLine);
        Console.WriteLine();
    }
}
