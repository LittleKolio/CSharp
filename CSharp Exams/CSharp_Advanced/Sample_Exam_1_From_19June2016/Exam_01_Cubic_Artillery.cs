using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_1_From_19June2016
{
    class Exam_01_Cubic_Artillery
    {
        static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Bunker") { break; }

                Queue<KeyValuePair<string, List<int>>> bunkers
                    = new Queue<KeyValuePair<string, List<int>>>();
                Queue<int> weapons = new Queue<int>();

                BunkersAndWeapons(input, ref bunkers, ref weapons);

                int tempBCount = bunkers.Count;

                for (int j = 1;
                    j <= tempBCount || bunkers.Count > 1;
                    j++)
                {
                    KeyValuePair<string, List<int>> tempBunker 
                        = bunkers.Dequeue();
                    bool remove = false;
                    int tempWCount = weapons.Count;

                    for (int i = 1; 
                        i <= tempWCount || weapons.Count > 1;
                        i++)
                    {
                        int tempWeapon = weapons.Dequeue();

                        if (capacity - tempBunker.Value.Sum() >= tempWeapon)
                        {
                            tempBunker.Value.Add(tempWeapon);
                            if (tempBunker.Value.Sum() == capacity)
                            {
                                Console.WriteLine($"{tempBunker.Key} -> " + string.Join(", ", b.Value));
                                remove = true;
                            }
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

        private static void BunkersAndWeapons(
            string[] input, 
            ref Queue<KeyValuePair<string, List<int>>> bunkers, 
            ref Queue<int> weapons)
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
