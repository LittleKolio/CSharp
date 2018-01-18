namespace Exercise_05_Linked_Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LinkedQueue<T> : IEnumerable<T>
        {

            private class QueueNode
            {
                public T Value { get; private set; }
                public QueueNode NextNode { get; set; }
                public QueueNode PrevNode { get; set; }

                public QueueNode(T value, QueueNode prevNode)
                {
                    this.Value = value;
                    prevNode.NextNode = this;
                    this.PrevNode = prevNode;
                    this.NextNode = null;
                }

                public QueueNode(T value)
                {
                    this.Value = value;
                    this.PrevNode = null;
                    this.NextNode = null;
                }
            }

            private QueueNode head;
            private QueueNode tail;
            public int Count { get; private set; }

            public void Enqueue(T element)
            {
                if (this.head == null)
                {
                    this.head = new QueueNode(element);
                    this.tail = this.head;
                }
                else
                {
                    QueueNode node = new QueueNode(element, this.tail);
                    this.tail = node;
                }

                this.Count++;
            }

            public T Dequeue()
            {
                if (this.head == null)
                {
                    throw new InvalidOperationException();
                }

                T element = this.head.Value;

                if (this.Count == 1)
                {
                    this.head = null;
                    this.tail = null;
                }
                else if (this.Count > 1)
                {
                    QueueNode node = this.head.NextNode;
                    this.head.NextNode = null;
                    node.PrevNode = null;
                    this.head = node;
                }
                this.Count--;

                return element;
            }
            public T[] ToArray()
            {
                T[] arr = new T[this.Count];

                QueueNode node = this.head;
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
            QueueNode node = this.head;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
