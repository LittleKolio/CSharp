namespace Exercise_07_Inferno_Infinity.Models.Weapons
{
    using Contracts;

    public class Axe : Weapon
    {
        private const int minDamage = 5;
        private const int maxDamage = 10;
        private const int numberSockets = 4;

        public Axe(string name, Rarity rarity, IMagicalStats[] gems) 
            : base(name, minDamage, maxDamage, rarity, gems)
        {
        }
    }
}
