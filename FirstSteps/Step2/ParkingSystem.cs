using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step2
{
    class ParkingSystem
    {
        static void Main ()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bool[,] park = new bool[input[0], input[1]];


            while (true)
            {
                string input2 = Console.ReadLine().Trim();
                if (input2.Contains("stop"))
                {
                    break;
                }

                int[] place = input2
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int count = Math.Abs(place[0] - place[1]) + place[2];

                if (!park[place[1], place[2]])
                {
                    park[place[1], place[2]] = true;
                    continue;
                }
                else
                {

                    for (int i = 1; i < input[1]; i++)
                    {
                        if (!park[place[1], i])
                        {

                        }
                    }
                }
            }

            foreach (bool e in park)
            {
                Console.WriteLine(e);
            }
        }
    }
}
