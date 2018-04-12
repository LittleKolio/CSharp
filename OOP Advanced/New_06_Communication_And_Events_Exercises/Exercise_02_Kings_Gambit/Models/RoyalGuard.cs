namespace Exercise_02_Kings_Gambit.Models
{
    using System;

    public class RoyalGuard : Subordinate
    {
        private const string action = "defending";
        private const int hits = 3;

        public RoyalGuard(string name) : base(name, action, hits)
        {
        }
    }
}
