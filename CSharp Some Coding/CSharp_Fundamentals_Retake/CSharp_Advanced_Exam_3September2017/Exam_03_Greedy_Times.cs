namespace Trash.CSharp_Advanced_Exam_3September2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam_03_Greedy_Times
    {
        public static Dictionary<string, long> gems;
        public static Dictionary<string, long> money;
        public static Dictionary<string, long> gold;

        public static void Main()
        {
            InitializeBag();

            long bagCapaity = long.Parse(Console.ReadLine());
            string[] items = SplitInput(Console.ReadLine(), " ");

            for (int i = 0; i < items.Length - 1; i += 2)
            {
                long goldAmount = gold.Values.Sum();
                long gemsAmount = gems.Values.Sum();
                long moneyAmount = money.Values.Sum();

                string item = items[i].ToLower();
                long amount = long.Parse(items[i + 1]);

                if (goldAmount + gemsAmount + moneyAmount + amount > bagCapaity)
                {
                    continue;
                }

                if (item == "gold")
                {
                    FillBag(gold, "Gold", amount);
                }
                else if (item.EndsWith("gem") &&
                    item.Length >= 4 &&
                    (amount + gemsAmount) <= goldAmount)
                {
                    FillBag(gems, items[i], amount);
                }
                else if (item.Length == 3 &&
                    (amount + moneyAmount) <= gemsAmount)
                {
                    FillBag(money, items[i], amount);
                }
            }

            if (gold.Any())
            {
                PrintBag(gold, "Gold");
            }
            if (gems.Any())
            {
                PrintBag(gems, "Gem");
            }
            if (money.Any())
            {
                PrintBag(money, "Cash");
            }

        }

        private static void FillBag(Dictionary<string, long> bagItems, string item, long amount)
        {
            if (!bagItems.ContainsKey(item))
            {
                bagItems.Add(item, 0);
            }
            bagItems[item] += amount;
        }

        private static void PrintBag(Dictionary<string, long> bagItems, string type)
        {
            Console.WriteLine($"<{type}> ${bagItems.Values.Sum()}");
            foreach (KeyValuePair<string, long> item
                in bagItems.OrderByDescending(i => i.Key)
                .ThenBy(i => i.Value))
            {
                Console.WriteLine($"##{item.Key} - {item.Value}");
            }
        }

        private static void InitializeBag()
        {
            gems = new Dictionary<string, long>();
            money = new Dictionary<string, long>();
            gold = new Dictionary<string, long>();
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
