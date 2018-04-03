namespace Exercise_07_Inferno_Infinity.Models.Weapons
{
    using Contracts;
    using Gems;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Weapon : IMagicalStats, IWeapon
    {
        private const int StrModMinDamage = 2;
        private const int StrModMaxDamage = 3;

        private const int AgiModMinDamage = 1;
        private const int AgiModMaxDamage = 4;

        private int minDamage;
        private int maxDamage;
        private Rarity rarity;

        private IMagicalStats[] gems;

        protected Weapon(string name, int minDamage, int maxDamage, Rarity rarity, IMagicalStats[] gems)
        {
            this.Name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.rarity = rarity;
            this.gems = gems;
        }

        public string Name { get; }

        private int MinDamage => 
            (int)this.rarity * this.minDamage + 
            this.Strength * StrModMinDamage +
            this.Agility * AgiModMinDamage;

        private int MaxDamage => 
            (int)this.rarity * this.maxDamage +
            this.Strength * StrModMaxDamage +
            this.Agility * AgiModMaxDamage;

        public int Strength => this.gems.Sum(g => g.Strength);
        public int Agility => this.gems.Sum(g => g.Agility);
        public int Vitality => this.gems.Sum(g => g.Vitality);

        public void AddGem(IMagicalStats gem, int socket)
        {
            if (socket < 0 || socket >= this.gems.Length)
            {
                return;
            }

            this.gems[socket] = gem;
        }

        public void RemoveGem(int socket)
        {
            if (socket < 0 || socket >= this.gems.Length)
            {
                return;
            }

            if (this.gems[socket] == null)
            {
                return;
            }

            this.gems[socket] = null;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
