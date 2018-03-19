namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        private List<Character> party;
        private List<Item> pool;

        public DungeonMaster()
        {
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.party = new List<Character>();
            this.pool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string type = args[1];
            args = args.Take(1).Skip(1).ToArray();

            Character character = characterFactory.CreateCharacter(type, args);
            this.party.Add(character);
            return string.Format(Constants.DungeonMaster_JoinParty, type);
        }

        public string AddItemToPool(string[] args)
        {
            string type = args[0];

            Item item = this.itemFactory.CreateItem(type);
            this.pool.Add(item);
            return string.Format(Constants.DungeonMaster_AddItemToPool, type);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];

            Character character = Validation.CharacterInCollection(this.party, name);
            Item item = Validation.ItemInPool(this.pool);
            character.ReceiveItem(item);

            return string.Format(Constants.DungeonMaster_PickUpItem, 
                name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string charName = args[0];
            string itemName = args[1];

            Character character = Validation.CharacterInCollection(this.party, charName);
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(Constants.DungeonMaster_UseItem,
                charName, itemName);
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = Validation.CharacterInCollection(this.party, giverName);
            Character receiver = Validation.CharacterInCollection(this.party, receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return string.Format(Constants.DungeonMaster_UseItemOn,
                giverName, itemName, receiverName);
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = Validation.CharacterInCollection(this.party, giverName);
            Character receiver = Validation.CharacterInCollection(this.party, receiverName);
            Item item = giver.Bag.GetItem(itemName);

            receiver.ReceiveItem(item);

            return string.Format(Constants.DungeonMaster_GiveCharacterItem,
                giverName, receiverName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            List<Character> sortedParty = party
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health)
                .ToList();

            foreach (Character character in sortedParty)
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = Validation.CharacterInCollection(this.party, attackerName);
            Character receiver = Validation.CharacterInCollection(this.party, receiverName);

            if (attacker is Warrior)
            {
                ((Warrior)attacker).Attack(receiver);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(Constants.Exception_IsWarrior, attackerName));
            }

            string result = string.Format(Constants.DungeonMaster_Attack,
                attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Name, receiver.Health, 
                receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);

            if (!receiver.IsAlive)
            {
                result = string.Concat(result, Environment.NewLine,
                    string.Format(Constants.DungeonMaster_ReceiverIsDead, receiver.Name));
            }

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = Validation.CharacterInCollection(this.party, healerName);
            Character receiver = Validation.CharacterInCollection(this.party, receiverName);

            if (healer is Cleric)
            {
                ((Cleric)healer).Heal(receiver);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(Constants.Exception_IsCleric, healerName));
            }

            return string.Format(Constants.DungeonMaster_Heal,
                healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
        }

        public string EndTurn(string[] args)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
