namespace Exercise_07_Inferno_Infinity.Models.Weapons
{
    using Contracts;

    public class Sword : Weapon
    {
        private const int minDamage = 4;
        private const int maxDamage = 6;
        private const int numberSockets = 3;

        public Sword(string name, Rarity rarity, IMagicalStats[] gems) 
            : base(name, minDamage, maxDamage, rarity, gems)
        {
        }
    }
}
