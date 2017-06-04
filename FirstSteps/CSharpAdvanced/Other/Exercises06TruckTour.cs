using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
    class Exercises06TruckTour
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Queue<double> queue = new Queue<double>();

            for (int i = 0; i < num; i++)
            {
                double[] tempArr = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                queue.Enqueue(tempArr[0] - tempArr[1]);
            }

            int index = 0;

            for (int i = 0; i < num; i++)
            {
                double tank = 0;
                bool empty = false;

                Queue<double> tempQueue = queue;
                tempQueue.TrimExcess();

                for (int j = 0; j < num; j++)
                {
                    tank += tempQueue.Peek();

                    if (tank < 0)
                    {
                        empty = true;
                        break;
                    }
                    tempQueue.Enqueue(tempQueue.Dequeue());
                }
                if (!empty)
                {
                    index = i;
                    break;
                }
                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine(index);
            
        }
    }
}
