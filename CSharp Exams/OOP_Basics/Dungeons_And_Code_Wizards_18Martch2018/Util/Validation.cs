namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Validation
    {
        public static void IsCharacterAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(
                    Constants.Character_IsAlive);
            }
        }

        public static Item ItemInBag(ICollection<Item> collection, string name)
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException(
                    Constants.Bag_IsEmpty);
            }

            Item item = collection.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(
                    string.Format(Constants.Bag_IsItem, name));
            }

            return item;
        }

        public static Character CharacterInCollection(ICollection<Character> collection, string name)
        {
            Character character = collection.FirstOrDefault(c => c.Name == name);
            if (character == null)
            {
                throw new ArgumentException(
                    string.Format(Constants.Exception_CharacterNotFound, name));
            }
            return character;
        }

        public static Item ItemInPool(ICollection<Item> collection)
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException(
                    Constants.Exception_NoItemsInPool);
            }

            Item item = collection.Last();

            return item;
        }
    }
}
