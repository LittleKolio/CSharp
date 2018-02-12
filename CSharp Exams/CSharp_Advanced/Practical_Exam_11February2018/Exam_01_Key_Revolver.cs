namespace Practical_Exam_11February2018
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam_01_Key_Revolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(SplitInput(Console.ReadLine(), " "));
            Stack<int> locks = new Stack<int>(SplitInput(Console.ReadLine(), " ").Reverse());
            int intelligence = int.Parse(Console.ReadLine());

            while (true)
            {
                for (int i = 0; i < barrel; i++)
                {
                    if (bullets.Count == 0 || locks.Count == 0)
                    {
                        break;
                    }

                    int currentBullet = bullets.Pop();
                    int currentLock = locks.Pop();

                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                        locks.Push(currentLock);
                    }

                    intelligence -= bulletPrice;
                }
                if (bullets.Count == 0 || locks.Count == 0)
                {
                    break;
                }
                Console.WriteLine("Reloading!");
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence}");
            }
        }

        private static int[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
