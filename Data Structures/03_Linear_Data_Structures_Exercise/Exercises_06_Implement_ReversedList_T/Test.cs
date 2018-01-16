namespace Exercises_06_Implement_ReversedList_T
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Test
    {
        public static void Main()
        {
            ReversedList<int> list = new ReversedList<int>();

            int startNum = 20;
            int count = 10;

            for (int i = 0; i < count; i++)
            {
                list.Add(startNum++);
            }

            PrintList(list);

            int remove = 3;

            list.RemoveAt(remove);

            PrintList(list);
        }

        private static void PrintList(ReversedList<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
