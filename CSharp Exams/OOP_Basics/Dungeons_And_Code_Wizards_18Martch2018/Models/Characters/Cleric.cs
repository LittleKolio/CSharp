using System;

namespace DungeonsAndCodeWizards
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(
                  name, 
                  Constants.Cleric_BaseHealth,
                  Constants.Cleric_BaseArmor,
                  Constants.Cleric_AbilityPoints, 
                  new Backpack(), 
                  faction)
        {
            base.RestHealMultiplier = Constants.Cleric_RestHealMultiplier;
        }

        public void Heal(Character character)
        {
            Validation.IsCharacterAlive(this);
            Validation.IsCharacterAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(
                    Constants.Cleric_HealEnemy);
            }

            character.ChangeHealt(base.AbilityPoints);
        }
    }
}
