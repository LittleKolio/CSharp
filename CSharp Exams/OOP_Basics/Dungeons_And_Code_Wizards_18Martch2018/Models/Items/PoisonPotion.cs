namespace DungeonsAndCodeWizards
{
    public class PoisonPotion : Item
    {
        public PoisonPotion() : base(Constants.Weight_PoisonPotion)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.ChangeHealt(-1 * Constants.Efect_PoisonPotion);
        }
    }
}
