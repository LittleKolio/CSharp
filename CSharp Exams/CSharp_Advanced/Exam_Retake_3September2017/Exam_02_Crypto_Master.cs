namespace Exam_Retake_3September2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam_02_Crypto_Master
    {
        public static void Main()
        {
            int[] sequence = Console.ReadLine()
                .Split(", ".ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int len = sequence.Length;
            int count = 0;

            for (int step = 1; step <= len && count < len; step++)
            {
                for (int index = len - 1; index >= 0; index--)
                {
                    int tempIndex = index;
                    int last = sequence[tempIndex];
                    int currentCount = 1;

                    while (true)
                    {
                        tempIndex = (tempIndex + step) % len;
                        int current = sequence[tempIndex];
                        if (current <= last)
                        {
                            break;
                        }
                        last = current;
                        currentCount++;
                    }

                    if (currentCount > count) { count = currentCount; }
                    if (count == len) { break; }
                }
            }

            Console.WriteLine(count);
        }
    }
}
