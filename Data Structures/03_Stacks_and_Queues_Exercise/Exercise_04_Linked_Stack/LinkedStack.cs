namespace Exercise_04_Linked_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class LinkedStack<T>
        : IEnumerable<T>
    {
        private class Node
        {
            public T Value { get; private set; }
            public Node NextNode { get; set; }

            public Node(T value, Node nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }

        private Node head;
        public int Count { get; private set; }

        public LinkedStack()
        {
            this.head = null;
            this.Count = 0;
        }

        public void Push(T element)
        {
            if (this.head == null)
            {
                this.head = new Node(element);
            }
            else
            {
                Node node = new Node(element, this.head);
                this.head = node;
            }

            this.Count++;
        }
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.head.Value;

            if (this.Count == 1)
            {
                this.head = null;
            }
            else
            {
                Node node = this.head;
                this.head = this.head.NextNode;
                node.NextNode = null;
            }

            this.Count--;

            return element;
        }
        public T[] ToArray()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T[] arr = new T[this.Count];

            //Node node = this.head;
            //int i = this.Count - 1;
            //while (node != null)
            //{
            //    arr[i] = node.Value;
            //    node = node.NextNode;
            //    i--;
            //}

            Node node = this.head;
            int i = 0;
            while (node != null)
            {
                arr[i] = node.Value;
                node = node.NextNode;
                i++;
            }

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = this.ToArray();

            foreach (T element in arr)
            {
                yield return element;
            }

            //for (int i = this.Count - 1; i >= 0; i++)
            //{
            //    yield return arr[i];
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
