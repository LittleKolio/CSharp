using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_1_From_19June2016
{
    class Exam_01_Cubic_Artillery
    {
        public static Queue<string> bunkers;
        public static Queue<int> weapons;

        static void Main()
        {
            bunkers = new Queue<string>();
            weapons = new Queue<int>();

            int capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Bunker") { break; }

                BunkersAndWeapons(input, capacity);

                string tempBunker;
                Queue<int> tempWeapons;
                int freeSpace;

                while (bunkers.Count > 1)
                {
                    freeSpace = capacity;
                    tempWeapons = new Queue<int>();
                    tempBunker = bunkers.Dequeue();

                    for (int j = 1; j < weapons.Count; j++)
                    {
                        int tempWeapon = weapons.Dequeue();
                        if (freeSpace >= tempWeapon)
                        {
                            tempWeapons.Enqueue(tempWeapon);
                            freeSpace -= tempWeapon;
                            j--;
                        }
                        else
                        {
                            weapons.Enqueue(tempWeapon);
                        }
                    }

                    Console.WriteLine($"{tempBunker} -> " +
                        string.Join(", ", tempWeapons));
                }

                freeSpace = capacity;
                tempWeapons = new Queue<int>();
                tempBunker = bunkers.Dequeue();

                if (weapons.Count == 0)
                {
                    Console.WriteLine($"{tempBunker} -> Empty");
                    break;
                }
                else
                {
                    while (weapons.Count > 0)
                    {
                        int tempWeapon = weapons.Dequeue();

                        if (freeSpace >= tempWeapon)
                        {
                            tempWeapons.Enqueue(tempWeapon);
                            freeSpace -= tempWeapon;
                        }
                        else
                        {
                            while (tempWeapons.Count > 0)
                            {
                                freeSpace += tempWeapons.Dequeue();
                                if (freeSpace >= tempWeapon)
                                {
                                    tempWeapons.Enqueue(tempWeapon);
                                    freeSpace -= tempWeapon;
                                    break;
                                }
                            }
                        }
                    }

                    Console.WriteLine($"{tempBunker} -> " +
                        string.Join(", ", tempWeapons));
                }
            }
        }

        private static void BunkersAndWeapons(string[] input, int capacity)
        {
            string bunker;
            foreach (string item in input)
            {
                int weapon;
                bool isWeapon = int.TryParse(item, out weapon);
                if (!isWeapon)
                {
                    bunker = item;
                    bunkers.Enqueue(bunker);
                }
                else if (capacity >= weapon)
                {
                    weapons.Enqueue(weapon);
                }
            }
        }
    }
}
