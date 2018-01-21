namespace Exercise_06_Sequence_N_M
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public class Item
        {
            public Item(int value, Item prevItem = null)
            {
                this.Value = value;
                this.PrevItem = prevItem;
            }

            public Item PrevItem { get; set; }
            public int Value { get; set; }
        }

        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = input[0];
            int end = input[1];

            Queue<Item> queue = new Queue<Item>();
            queue.Enqueue(new Item(start));

            while (queue.Count > 0)
            {
                Item num = queue.Dequeue();

                if (num.Value == end)
                {
                    PrintSequence(num);
                    return;
                }

                if (num.Value < end)
                {
                    queue.Enqueue(new Item(num.Value + 1, num));
                    queue.Enqueue(new Item(num.Value + 2, num));
                    queue.Enqueue(new Item(num.Value * 2, num));
                }
            }


        }

        private static void PrintSequence(Item num)
        {
            LinkedList<int> list = new LinkedList<int>();

            Item item = num;
            while (item != null)
            {
                list.AddFirst(item.Value);
                item = item.PrevItem;
            }

            Console.WriteLine(string.Join(" -> ", list));
        }
    }
}
