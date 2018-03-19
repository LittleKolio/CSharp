using System;

namespace DungeonsAndCodeWizards
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) 
            : base(
                  name, 
                  Constants.Warrior_BaseHealth, 
                  Constants.Warrior_BaseArmor, 
                  Constants.Warrior_AbilityPoints, 
                  new Satchel(),
                  faction)
        {
        }

        public void Attack(Character character)
        {
            Validation.IsCharacterAlive(this);
            Validation.IsCharacterAlive(character);

            if (character == this)
            {
                throw new InvalidOperationException(
                    Constants.Warrior_SelfAttack);
            }

            if (this.Faction == character.Faction)
            {
                throw new InvalidOperationException(
                    string.Format(Constants.Warrior_FriendlyFire, this.Faction));
            }

            character.TakeDamage(base.AbilityPoints);
        }
    }
}
