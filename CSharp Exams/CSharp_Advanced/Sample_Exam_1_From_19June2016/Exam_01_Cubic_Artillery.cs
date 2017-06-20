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

                Dictionary<string, List<int>> bunkers
                    = new Dictionary<string, List<int>>();
                Queue<int> weapons = new Queue<int>();

                BunkersAndWeapons(input, ref bunkers, ref weapons);

                
                foreach (var b in bunkers)
                {
                    bool remove = false;
                    int tempCount = weapons.Count;

                    for (int i = 1; 
                        i <= weapons.Count || weapons.Count > 1;
                        i++)
                    {
                        int tempWeapon = weapons.Dequeue();
                        if (capacity - b.Value.Sum() >= tempWeapon)
                        {
                            b.Value.Add(tempWeapon);
                            if (b.Value.Sum() == capacity)
                            {
                                Console.WriteLine($"{b.Key} -> " + string.Join(", ", b.Value));
                                remove = true;
                            }
                        }
                    }

                    if (remove)
                    {
                        bunkers.Remove(b.Key);
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
            ref Dictionary<string, List<int>> bunkers, 
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
                    bunkers.Add(bunker, new List<int>());
                }
                else
                {
                    weapons.Enqueue(weapon);
                }
            }
        }
    }
}
