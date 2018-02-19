namespace Exercise_05_Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Loot
    {
        public string Type { get; set; }
        public long Value { get; set; }
        public Loot(long value, string type)
        {
            this.Value = value;
            this.Type = type;
        }
    }
}
