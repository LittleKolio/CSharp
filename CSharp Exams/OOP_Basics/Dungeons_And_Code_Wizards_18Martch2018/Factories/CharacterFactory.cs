namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CharacterFactory
    {
        public Character CreateCharacter(string[] args)
        {
            string inFaction = args[0];
            string type = args[1];
            string name = args[2];

            Faction faction;
            if (!Enum.TryParse(inFaction, out faction))
            {
                throw new ArgumentException(
                    string.Format(Constants.Exception_Faction, inFaction));
            }

            switch (type)
            {
                case "Warrior": return new Warrior(name, faction);
                case "Cleric": return new Cleric(name, faction);
                default:
                    throw new ArgumentException(
                        string.Format(Constants.Exception_InvalidCharacter, type));
            }
        }
    }
}
