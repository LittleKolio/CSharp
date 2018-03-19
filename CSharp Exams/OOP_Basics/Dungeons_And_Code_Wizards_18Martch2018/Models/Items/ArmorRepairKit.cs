namespace DungeonsAndCodeWizards
{
    using System;

    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit() : base(Constants.Weight_ArmorRepairKit)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.ChangeArmor();
        }
    }
}
