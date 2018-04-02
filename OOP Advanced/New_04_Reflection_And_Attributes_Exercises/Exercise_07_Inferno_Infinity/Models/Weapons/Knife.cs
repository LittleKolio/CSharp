namespace Exercise_07_Inferno_Infinity.Models.Weapons
{
    using Contracts;

    public class Knife : Weapon
    {
        private const int minDamage = 3;
        private const int maxDamage = 4;
        private const int numberSockets = 2;

        public Knife(string name, Rarity rarity, IMagicalStats[] gems) 
            : base(name, minDamage, maxDamage, rarity, gems)
        {
        }
    }
}
