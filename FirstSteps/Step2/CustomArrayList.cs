using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step2
{
    public class CustomArrayList
    {
        private object[] arr;
        private int count;

        /// <summary>
        /// Returns the actual list length
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Initialize the array-based list -> allocate memory
        /// </summary>
        private static readonly int INITIAL_CAPACITY = 4;
        public CustomArrayList()
        {
            arr = new object[INITIAL_CAPACITY];
            count = 0;
        }

        /// <summary>
        /// Add element to the list
        /// </summary>
        /// <param name="item">The element you want to add</param>
        public void Add(object item)
        {
            Insert(count, item);
        }

        /// <summary>
        /// Insert the specified element at the given position in this list
        /// </summary>
        /// <param name="index">Element to be inserted</param>
        /// <exception cref="System.IndexOutOfRangeException">Index is invalide</exception>
        public void Insert(int index, object item)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index" + index);
            }

            object[] extendedArr = arr;
            if (count + 1 == arr.Length)
            {
                extendedArr = new object[arr.Length * 2];
            }

            // copy items until [index], leave [index] empty and continue from [index + 1]
            Array.Copy(arr, extendedArr, index);

            //increase array with one item
            count++;
            Array.Copy(arr, index, extendedArr, index + 1, count - index - 1);
            extendedArr[index] = item;
            arr = extendedArr;
        }

        /// <summary>
        /// Returns the index of the first occurrence of the specified element in the list
        /// </summary>
        /// <param name="item">The element your are searching</param>
        /// <returns>The index of given element or -1 not found</returns>
        public int IndexOf(object item)
        {
            // ?? count
            for (int i = 0; i < arr.Length; i++)
            {
                if (item == arr[i])
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Clear the list
        /// </summary>
        public void Clear()
        {
            arr = new object[INITIAL_CAPACITY];
            count = 0;
        }

        /// <summary>
        /// Check if element exists
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns>If item exists</returns>
        public bool Contains(object item)
        {
            int index = IndexOf(item);
            bool found = index != -1;
            return found;
        }

        /// <summary>
        /// Retrives element on the set index
        /// </summary>
        /// <param name="index">Index of the element</param>
        /// <returns>The element on the given position</returns>
        public object this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalide index: " + index);
                }
                return arr[index];
            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalide index: " + index);
                }
                arr[index] = value;
            }
        }

        /// <summary>
        /// Removes element on the given index
        /// </summary>
        /// <param name="index">Index of the element to remove</param>
        /// <return>The removed element</return>
        public object RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalide index: " + index);
            }
            object item = arr[index];
            Array.Copy(arr, index + 1, arr, index, count - index + 1);
            arr[count - 1] = null;
            count--;

            return item;
        }

        /// <summary>
        /// Removes the specified item
        /// </summary>
        /// <param name="item">The item you want to remove</param>
        /// <return>Item index or -1 if item does not exists</return>
        public int Remove(object item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return index;
            }

            Array.Copy(arr, index + 1, arr, index, count - index + 1);
            arr[count - 1] = null;
            count--;

            return index;
        }

        public static void Main()
        {
            CustomArrayList shopingList = new CustomArrayList();
            shopingList.Add("Milk");
            shopingList.Add("Honey");
            shopingList.Add("Olives");
            shopingList.Add("Beer");
            shopingList.Remove("Olives");
            Console.WriteLine("We need to buy: ");
            for (int i = 0; i < shopingList.Count; i++)
            {
                Console.WriteLine(shopingList[i]);
            }
            Console.WriteLine("Do we need to buy Bread? " + shopingList.Contains("Bread"));
        }
    }


}
