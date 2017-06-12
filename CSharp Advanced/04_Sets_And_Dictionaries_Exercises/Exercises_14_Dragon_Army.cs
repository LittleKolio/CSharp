using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_And_Dictionaries_Exercises
{
    class Exercises_14_Dragon_Army
    {
        private const int DefDamage = 45;
        private const int DefHealth = 250;
        private const int DefArmor = 10;

        static void Main()
        {
            Dictionary<string, Dictionary<string, int[]>> dragons 
                = new Dictionary<string, Dictionary<string, int[]>>();

            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string[] dragon = Console.ReadLine()
                    .Split(new[] { ' ' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                string type = dragon[0];
                string name = dragon[1];
                int dam = dragon[2].Equals("null") ? DefDamage : int.Parse(dragon[2]);
                int heal = dragon[3].Equals("null") ? DefHealth : int.Parse(dragon[3]);
                int ar = dragon[4].Equals("null") ? DefArmor : int.Parse(dragon[4]);

                int[] stats = { dam, heal, ar };

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(
                        type,
                        new Dictionary<string, int[]>
                        { { name, stats } });
                }
                else
                {
                    if (!dragons[type].ContainsKey(name))
                    {
                        dragons[type].Add(name, stats);
                    }
                    else
                    {
                        dragons[type][name] = stats;
                    }
                }
            }

            PrintDragons(dragons);
        }

        private static void PrintDragons(
            Dictionary<string, Dictionary<string, int[]>> dragons)
        {
            foreach (var dragon in dragons)
            {
                StringBuilder stats = new StringBuilder();
                double damageAvr = 0, healthAvr = 0, armorAvr = 0;
                foreach (var item in dragon.Value.OrderBy(e => e.Key))
                {
                    stats.Append($"-{item.Key} -> damage: {item.Value[0]}, health: {item.Value[1]}, armor: {item.Value[2]}\r\n");
                    damageAvr += item.Value[0];
                    healthAvr += item.Value[1];
                    armorAvr += item.Value[2];
                }

                damageAvr /= dragon.Value.Count;
                healthAvr /= dragon.Value.Count;
                armorAvr /= dragon.Value.Count;

                Console.WriteLine($"{dragon.Key}::({damageAvr:F2}/{healthAvr:F2}/{armorAvr:F2})");
                Console.Write(stats);
            }
        }
    }
}
