using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_1_From_19June2016
{
    /// <summary>
    /// You will be given n - an integer specifying the bunker's maximum capacity.
    /// Then you will be given input lines which will contain English alphabet letters and numbers, 
    /// separated by a single space.
    /// The letters represent the bunkers and the numbers - the weapons and their capacity.
    /// Weapons must be stored in the bunkers.
    /// When a bunker cannot contain a given weapon due to lack of enough free capacity it overflows, 
    /// and passes the weapon to the next entered bunker, then to the next, 
    /// and so on till the last entered bunker.
    /// If there is no bunker that can hold the given weapon, ignore that weapon.
    /// If there are no other bunkers besides the current one, 
    /// you must check if current weapon can actually be contained.
    /// If the weapon can be contained, you must make enough free capacity to hold that weapon, 
    /// by removing weapons, starting from the first entered, till the last.
    /// If a bunker overflows you must remove it, and print it on the console.
    /// If there are no other bunkers, you must NOT remove the one that overflowed.
    /// </summary>
    /// <output>
    /// You must print a bunker, every time it overflows, after removing it.
    /// The format is the following: {bunker} -> {weapon1}, {weapons2}
    /// In case a bunker has no weapons, just print "Empty".
    /// </output>
    /// <remarks>
    /// The bunkers will only be English alphabet letters.
    /// Each bunker's letter will always be unique.
    /// The integer n will be In the range [0, 500].
    /// The weapons will always be valid integers in the range [0, 500].
    /// Allowed time/memory: 100ms/16MB.
    /// </remarks>
    class Exam_01_Cubic_Artillery
    {
        static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());

            Queue<string> bunkers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();
            

            string input;
            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                string[] formatInput = input
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                foreach (string item in formatInput)
                {
                    int weapon;
                    bool isWeapon = int.TryParse(item, out weapon);
                    if (!isWeapon)
                    {
                        bunkers.Enqueue(item);
                    }
                    else if (weapon <= capacity)
                    {
                        weapons.Enqueue(weapon);
                    }
                }

                int freeSpace = capacity;
                List<int> currentWs = new List<int>();

                while (weapons.Count > 0)
                {
                    int currentW = weapons.Dequeue();
                    bool saved = false;
                    while (bunkers.Count > 1)
                    {
                        if (freeSpace >= currentW)
                        {
                            currentWs.Add(currentW);
                            freeSpace -= currentW;
                            saved = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", currentWs)}");
                        }
                        freeSpace = capacity;
                        currentWs.Clear();
                    }

                    if (!false)
                    {
                        if (freeSpace >= currentW)
                        {
                            currentWs.Add(currentW);
                            freeSpace -= currentW;
                        }

                    }
                }

                if (weapons.Count == 0 && bunkers.Count > 0)
                {
                    Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                    break;
                }
            }
        }
    }
}
