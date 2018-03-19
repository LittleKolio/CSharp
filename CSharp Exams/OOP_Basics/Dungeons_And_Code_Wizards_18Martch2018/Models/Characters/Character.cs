namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Character
    {
        protected Character(
            string name,
            double health,
            double armor, 
            double abilityPoints, 
            Bag bag, 
            Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = Constants.Default_RestHealMultiplier;
        }



        private string name;
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        Constants.IsNullOrWhiteSpace);
                }
                this.name = value;
            }
        }

        private double healt;
        public double Health
        {
            get { return this.healt; }
            private set
            {
                if (value <= 0 || value > this.BaseHealth)
                {
                    throw new ArgumentOutOfRangeException(
                        "Healt ... ArgumentException");
                }
                this.healt = value;
            }
        }

        private double armor;
        public double Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0 || value > this.BaseArmor)
                {
                    throw new ArgumentOutOfRangeException(
                        "Armor ... ArgumentException");
                }
                this.armor = value;
            }
        }

        public Bag Bag { get; private set; }
        public bool IsAlive { get; private set; }
        protected double RestHealMultiplier { get; set; }
        public double AbilityPoints { get; protected set; }

        public double BaseHealth { get; }
        public double BaseArmor { get; }
        public Faction Faction { get; }


        public void TakeDamage(double hitPoints)
        {
            Validation.IsCharacterAlive(this);

            try
            {
                this.ChangeArmor(-1 * hitPoints);
            }
            catch
            {
                this.ChangeHealt(-1 * (hitPoints - this.Armor));
                this.Armor = 0;
            }
        }

        public void Rest()
        {
            Validation.IsCharacterAlive(this);

            this.ChangeHealt(this.BaseHealth * this.RestHealMultiplier);
        }

        public void UseItem(Item item)
        {
            Validation.IsCharacterAlive(this);
            
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            Validation.IsCharacterAlive(this);

            item.AffectCharacter(character);
        }

        public void ReceiveItem(Item item)
        {
            this.Bag.AddItem(item);
        }

        public void ChangeHealt(double amount)
        {
            try
            {
                this.Health += amount;
            }
            catch
            {
                this.IsAlive = false;
            }
        }

        public void ChangeArmor()
        {
            this.Armor = this.BaseArmor;
        }

        public void ChangeArmor(double amount)
        {
            this.Armor += amount;
        }

        private string Status => this.IsAlive ? "Alive" : "Dead";

        public override string ToString()
        {
            return string.Format(Constants.Character_ToString,
                this.Name, this.Health, this.BaseHealth, this.Armor, this.BaseArmor, this.Status);
        }
    }
}
