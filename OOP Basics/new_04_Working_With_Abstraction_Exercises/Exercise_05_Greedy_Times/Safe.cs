namespace Exercise_05_Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Safe
    {
        public static Bag bag;
        public static void Main()
        {
            long bagCapaity = long.Parse(Console.ReadLine());
            bag = new Bag(bagCapaity);

            string[] items = SplitInput(Console.ReadLine(), " ");

            for (int i = 0; i < items.Length - 1; i += 2)
            {
                long value = long.Parse(items[i + 1]);
                if (bag.LootSum + value > bagCapaity)
                {
                    continue;
                }

                string loot = ParseCommand(items[i].ToLower());
                if (loot == null)
                {
                    continue;
                }

                FillBag(loot, items[i], value);
            }

            if (bag.GoldSum > 0)
            {
                PrintResult("Gold");
            }

            if (bag.GemsSum > 0)
            {
                PrintResult("Gem");
            }

            if (bag.CashSum > 0)
            {
                PrintResult("Cash");
            }
        }

        private static void PrintResult(string typeOfLoot)
        {
            List<Loot> loot = bag.Loot
                .FindAll(l => l.GetType().Name == typeOfLoot)
                .OrderByDescending(g => g.Type)
                .ThenBy(g => g.Value)
                .ToList();
            long sumOfLoot = loot.Sum(l => l.Value);
            Console.WriteLine("<{0}> ${1}", typeOfLoot, sumOfLoot);
            foreach (Loot l in loot)
            {
                Console.WriteLine(l);
            }
        }

        private static void FillBag(string loot, string input, long value)
        {
            switch (loot)
            {
                case "gold":
                    {
                        bag.Loot.Find(l => l.GetType().Name == "Gold").Value += value;
                    } break;
                case "gem":
                    {
                        if (bag.GemsSum + value > bag.GoldSum)
                        {
                            return;
                        }
                        bag.Loot.Add(new Gem(value, input));
                    } break;
                case "cash":
                    {
                        if (bag.CashSum + value > bag.GemsSum)
                        {
                            return;
                        }
                        bag.Loot.Add(new Cash(value, input));
                    } break;
                default:
                    break;
            }
        }

        private static string ParseCommand(string input)
        {
            if (input == "gold")
            {
                return "gold";
            }
            else if (input.EndsWith("gem") && input.Length >= 4)
            {
                return "gem";
            }
            else if (input.Length == 3)
            {
                return "cash";
            }
            else
            {
                return null;
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
