﻿namespace Exercise_07_Inferno_Infinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int strength = 7;
        private const int agility = 2;
        private const int vitality = 5;

        public Ruby(Clarity clarity)
            : base(strength, agility, vitality, clarity)
        {
        }
    }
}
