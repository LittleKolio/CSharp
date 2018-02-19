namespace Exercise_05_Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Gem : Loot
    {
        public Gem(long value, string type) : base(value, type)
        {
        }
        public override string ToString()
        {
            return $"##{base.Type} - {base.Value}";
        }
    }
}
