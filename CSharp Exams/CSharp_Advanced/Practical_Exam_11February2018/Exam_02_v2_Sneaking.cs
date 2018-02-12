namespace Practical_Exam_11February2018
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam_02_v2_Sneaking
    {
        public static Dictionary<int[], char> list;
        public static int lines;
        public static int length;

        public static void Main()
        {
            list = new Dictionary<int[], char>();
            lines = int.Parse(Console.ReadLine());
            MatrixReadNLines();



            PrintRoom();
        }

        private static void PrintRoom()
        {
            List<KeyValuePair<int[], char>> newList = list.OrderBy(c => c.Key[0]).ToList();
            for (int row = 0, listIndex = 0; row < lines; row++)
            {
                if (newList[listIndex].Key[0] != row)
                {
                    Console.Write(new string('.', length));
                }
                else
                {
                    Console.Write(new string('.', newList[listIndex].Key[1]));
                    Console.Write(newList[listIndex].Value);
                    Console.Write(new string('.', length - (newList[listIndex].Key[1] + 1)));

                    listIndex++;
                }
                Console.WriteLine();
            }
        }

        private static void MatrixReadNLines()
        {
            for (int row = 0; row < lines; row++)
            {
                string input = Console.ReadLine();
                if (length == 0)
                {
                    length = input.Length;
                }
                FillList(input, "SNbd", row);
            }
        }

        private static void FillList(string line, string symbols, int row)
        {
            int index = line.IndexOfAny(symbols.ToCharArray());
            if (index != -1)
            {
                list.Add(new int[] { row, index }, line[index]);
            }
        }
    }
}
