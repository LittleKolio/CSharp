namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class HealthPotion : Item
    {
        public HealthPotion() : base(Constants.Weight_HealthPotion)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.ChangeHealt(Constants.Efect_HealthPotion);
        }
    }
}
