namespace Exercise_02_Kings_Gambit.Models
{
    using System;

    public class Footman : Subordinate
    {
        private const string action = "panicking";
        private const int hits = 2;

        public Footman(string name) : base(name, action, hits)
        {
        }
    }
}
