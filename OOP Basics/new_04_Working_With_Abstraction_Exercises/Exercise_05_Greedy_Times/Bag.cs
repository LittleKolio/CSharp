namespace Exercise_05_Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bag
    {
        public long Capacity { get; set; }
        public List<Loot> Loot { get; set; }

        public long GoldSum
        {
            get { return this.Loot.FindAll(l => l.GetType().Name == "Gold").Sum(g => g.Value); }
        }
        public long GemsSum
        {
            get { return this.Loot.FindAll(l => l.GetType().Name == "Gem").Sum(g => g.Value); }
        }
        public long CashSum
        {
            get { return this.Loot.FindAll(l => l.GetType().Name == "Cash").Sum(c => c.Value); }
        }
        public long LootSum
        {
            get { return this.GoldSum + this.GemsSum + this.CashSum; }
        }

        public Bag(long capacity)
        {
            this.Capacity = capacity;
            this.Loot = new List<Loot>
            {
                new Gold(0, "Gold")
            };
        }
    }
}
