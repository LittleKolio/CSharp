namespace Step2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents dynamic list implementation
    /// </summary>
    public class DynamicList
    {
        private class Node
        {
            private object element;
            private Node next;

            public object Element
            {
                get { return this.element; }
                set { this.element = value; }
            }
            public Node Next
            {
                get { return this.next; }
                set { this.next = value; }
            }

            public Node(object element, Node prevNode)
            {
                this.element = element;
                prevNode.next = this;
            }

            public Node(object element)
            {
                this.element = element;
                this.next = null;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public DynamicList()
        {
            tail = null;
            head = null;
            count = 0;
        }

        /// <summary>
        /// Add element at the end of the list
        /// </summary>
        /// <param name="item">The element you want to add</param>
        public void Add(object item)
        {
            if (head == null)
            {
                // If we have empty list
                head = new Node(item);
                tail = head;
            }
            else
            {
                // Else non-empty list
                Node newNode = new Node(item, tail);
                tail = newNode;
            }

            count++;
        }

        /// <summary>
        /// Removes and returns element on the specific index
        /// </summary>
        /// <param name="index">
        /// The index of the element you want to remove
        /// </param>
        /// <returns>The removed element</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Index is invalide
        /// </exception>
        public object RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Invalide index: " + index);
            }

            int currentIndex = 0;
            Node currentNode = head;
            Node prevNode = null;

            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            count--;

            if (count == 0)
            {
                head = null;
            }
            else if (prevNode == null)
            {
                head = currentNode.Next;
            }
            else
            {
                prevNode.Next = currentNode.Next;
            }

            Node lastElement = null;
            if (head != null)
            {
                lastElement = head;
                while(lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
            }
            tail = lastElement;
            return currentNode.Element;
        }

        /// <summary>
        /// Remove the specified item and returns index
        /// </summary>
        /// <param name="item">The element you want to remove</param>
        /// <returns>
        /// The index of the element or -1 if dose not exists
        /// </returns>
        public int Remove(object item)
        {
            int currentIndex = 0;
            Node currentNode = head;
            Node prevNode = null;

            while (currentNode != null)
            {
                if ((currentNode.Element != null &&
                    currentNode.Element.Equals(item)) ||
                    (currentNode.Element == null) &&
                    (item == null))
                {
                    break;
                }
                prevNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            if (currentNode != null)
            {
                count--;
                if (count == 0)
                {
                    head = null;
                }
                else if (prevNode == null)
                {
                    head = currentNode.Next;
                }
                else
                {
                    prevNode = currentNode.Next;
                }

                Node lastElement = null;
                if (head != null)
                {
                    lastElement = head;
                    while (lastElement.Next != null)
                    {
                        lastElement = lastElement.Next;
                    }
                }
                tail = lastElement;

                return currentIndex;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Search for given element in the list
        /// </summary>
        /// <param name="item">The item you are searching for</param>
        /// <returns>
        /// The index of the first occurrence of the element in the list or -1 when not found
        /// </returns>
        public int IndexOf(object item)
        {
            int index = 0;
            Node current = head;
            while (current != null)
            {
                if ((current.Element != null && current.Element == item) ||
                    (current.Element == null) && (item == null))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Check if the specified element exist in the list
        /// </summary>
        /// <param name="item">The item you are searching for</param>
        /// <returns>
        /// True if the element exists or false otherwise
        /// </returns>
        public bool Contains(object item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
        }

        /// <summary>
        /// Gets or sets the element on the specified position
        /// </summary>
        /// <param name="index">
        /// The position of the element [0 ... count - 1]
        /// </param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Index is invalide
        /// </exception>
        public object this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalide index: " + index);
                }
                Node currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Element;
            }

            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Invalide index: " + index);
                }
                Node currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Element = value;
            }
        }

        /// <summary>
        /// Gets the number of element in the list
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }

        public static void Main()
        {
            DynamicList shoppingList = new DynamicList();
            shoppingList.Add("Milk");
            shoppingList.Add("Honey");
            shoppingList.Add("Olives");
            shoppingList.Add("Beer");
            shoppingList.Remove("Olives");
            Console.WriteLine("We need to buy:");
            for (int i = 0; i < shoppingList.Count; i++)
            {
                Console.WriteLine(shoppingList[i]);
            }
            Console.WriteLine("Do we have to buy Bread? " +
                shoppingList.Contains("Bread"));
        }
    }
}
