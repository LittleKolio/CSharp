namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; }

        public virtual void AffectCharacter(Character character)
        {
            Validation.IsCharacterAlive(character);
        }
    }
}
