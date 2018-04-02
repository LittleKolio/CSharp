namespace Exercise_07_Inferno_Infinity.Models.Gems
{
    using Contracts;

    public abstract class Gem : IMagicalStats
    {
        private int strength;
        private int agility;
        private int vitality;
        private Clarity clarity;

        protected Gem(int strength, int agility, int vitality, Clarity clarity)
        {
            this.strength = strength;
            this.agility = agility;
            this.vitality = vitality;
            this.clarity = clarity;
        }

        public int Strength => this.strength + (int)this.clarity;
        public int Agility => this.agility + (int)this.clarity;
        public int Vitality => this.vitality + (int)this.clarity;
    }
}
