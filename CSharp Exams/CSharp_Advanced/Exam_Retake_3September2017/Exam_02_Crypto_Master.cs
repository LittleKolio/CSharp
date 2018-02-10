namespace Exam_Retake_3September2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// You will receive a sequence of numbers. This sequence forms a circle, 
    /// so the last number is just before the first one and the first number is right after the last one.
    /// You can start from any number in the circle and move to another one and choose any size for the step. 
    /// The direction must be from left-to-right. There are four rules you should keep:
    /// You should always jump to a larger number than the one you are currently on.
    /// You cannot jump on the same number more than once per try.
    /// The size of the jumping step can vary in the range 1 - the size of the sequence of numbers.
    /// The size of the step should be constant within a single try
    /// 
    /// </summary>
    /// <output>
    /// You should print the count of longest sequence, which you have found.
    /// The numbers of the sequence are in increasing order
    /// </output>
    /// <remarks>
    /// The count of numbers will be between 1 and 2500 inclusive.
    /// Each of the number will be between -1000 - 1000.
    /// Allowed working time for your program: 0.2 seconds. 
    /// Allowed memory:16 MB.
    /// </remarks>

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
