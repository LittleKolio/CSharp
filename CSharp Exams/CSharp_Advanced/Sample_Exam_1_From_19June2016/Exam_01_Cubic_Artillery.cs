using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_1_From_19June2016
{
    class Exam_01_Cubic_Artillery
    {
        public static Queue<KeyValuePair<string, List<int>>> bunkers;
        public static Queue<int> weapons;

        static void Main()
        {
            bunkers = new Queue<KeyValuePair<string, List<int>>>();
            weapons = new Queue<int>();

            int capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Bunker") { break; }

                BunkersAndWeapons(input);

                if (bunkers.Count == 1)
                {
                    KeyValuePair<string, List<int>> tempBunker = bunkers.Dequeue();
                    int freeSpace = capacity - tempBunker.Value.Sum();

                    for (int i = 1; weapons.Count > 1; i++)
                    {
                        int tempWeapon = weapons.Dequeue();

                        if (freeSpace >= tempWeapon)
                        {
                            tempBunker.Value.Add(tempWeapon);
                            if (tempBunker.Value.Sum() == capacity)
                            {
                                Console.WriteLine($"{tempBunker.Key} -> " + string.Join(", ", tempBunker.Value));
                            }
                        }
                        else if (capacity >= tempWeapon)
                        {
                            List<int> newList = new List<int>();
                            int tempSum = freeSpace;
                            int count = tempBunker.Value.Count;
                            for (int k = 0; k < count; k++)
                            {
                                tempSum += tempBunker.Value[k];
                                if (tempSum >= tempWeapon)
                                {
                                    newList.AddRange(weapons.Skip(k + 1));
                                    newList.Add(tempWeapon);
                                }
                            }
                            if (newList.Count > 0)
                            {

                            }
                        }
                    }
                }

                for (int j = 1; bunkers.Count > 1; j++)
                {
                    KeyValuePair<string, List<int>> tempBunker = bunkers.Dequeue();
                    bool remove = false;

                    for (int i = 1; weapons.Count > 1; i++)
                    {
                        int tempWeapon = weapons.Dequeue();

                        if (capacity - tempBunker.Value.Sum() >= tempWeapon)
                        {
                            tempBunker.Value.Add(tempWeapon);
                            if (tempBunker.Value.Sum() == capacity)
                            {
                                Console.WriteLine($"{tempBunker.Key} -> " + string.Join(", ", tempBunker.Value));
                                remove = true;
                            }
                        }
                        else
                        {
                            weapons.Enqueue(tempWeapon);
                        }
                    }

                    if (!remove)
                    {
                        bunkers.Enqueue(tempBunker);
                    }

                }

                if (bunkers.Count == 1 && 
                    !bunkers.FirstOrDefault().Value.Any())
                {
                    Console.WriteLine($"{bunkers.FirstOrDefault().Key} -> Empty");
                }
            }
        }

        private static void BunkersAndWeapons(string[] input)
        {
            string bunker;
            for (int i = 0; i < input.Length; i++)
            {
                int weapon;
                bool isWeapon = int.TryParse(input[i], out weapon);
                if (!isWeapon)
                {
                    bunker = input[i];
                    bunkers.Enqueue(
                        new KeyValuePair<string, List<int>>(
                            bunker, new List<int>()));
                }
                else
                {
                    weapons.Enqueue(weapon);
                }
            }
        }
    }
}
