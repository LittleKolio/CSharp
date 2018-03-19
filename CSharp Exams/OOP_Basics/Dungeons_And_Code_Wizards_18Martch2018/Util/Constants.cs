namespace DungeonsAndCodeWizards
{
    public static class Constants
    {
        public static string Bag_IsFull = "Bag is full!";
        public static string Bag_IsEmpty = "Bag is empty!";
        public static string Bag_IsItem = "No item with name {0} in bag!";
        public static string IsNullOrWhiteSpace = "Name cannot be null or whitespace!";
        public static string Character_IsAlive = "Must be alive to perform this action!";
        public static string Character_ToString = "{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}";

        public static int Weight_HealthPotion = 5;
        public static int Weight_PoisonPotion = 5;
        public static int Weight_ArmorRepairKit = 10;

        public static double Efect_HealthPotion = 20;
        public static double Efect_PoisonPotion = 20;

        public static int Capacity_Backpack = 100;
        public static int Capacity_Satchel = 20;

        public static double Default_RestHealMultiplier = 0.2;

        public static string Warrior_SelfAttack = "Cannot attack self!";
        public static string Warrior_FriendlyFire = "Friendly fire! Both characters are from {0} faction!";
        public static double Warrior_BaseHealth = 100;
        public static double Warrior_BaseArmor = 50;
        public static double Warrior_AbilityPoints = 40;

        public static string Cleric_HealEnemy = "Cannot heal enemy character!";
        public static double Cleric_BaseHealth = 50;
        public static double Cleric_BaseArmor = 25;
        public static double Cleric_AbilityPoints = 40;
        public static double Cleric_RestHealMultiplier = 0.5;

        public static string DungeonMaster_JoinParty = "{0} joined the party!";
        public static string DungeonMaster_AddItemToPool = "{0} added to pool.";
        public static string DungeonMaster_PickUpItem = "{0} picked up {1}!";
        public static string DungeonMaster_UseItem = "{0} used {1}.";

        /// <summary>
        /// "{giverName} used {itemName} on {receiverName}."
        /// </summary>
        public static string DungeonMaster_UseItemOn = "{0} used {1} on {2}.";

        /// <summary>
        /// "{giverName} gave {receiverName} {itemName}."
        /// </summary>
        public static string DungeonMaster_GiveCharacterItem = "{0} gave {1} {2}.";

        /// <summary>
        /// "{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiverHealth}/{receiverBaseHealth} HP and {receiverArmor}/{receiverBaseArmor} AP left!"
        /// </summary>
        public static string DungeonMaster_Attack = "{0} attacks {1} for {2} hit points! {3} has {4}/{5} HP and {6}/{7} AP left!";

        /// <summary>
        /// "{receiverName} is dead!"
        /// </summary>
        public static string DungeonMaster_ReceiverIsDead = "{0} is dead!";

        /// <summary>
        /// "{healerName} heals {receiverName} for {healerAbilityPoints}! {receiverName} has {receiverHealth} health now!"
        /// </summary>
        public static string DungeonMaster_Heal = "{0} heals {1} for {2}! {3} has {4} health now!";

        public static string Exception_Argument = "Parameter Error: {0}";
        public static string Exception_InvalidOperation = "Invalid Operation: {0}";
        public static string Exception_Faction = "Invalid faction \"{0}\"!";
        public static string Exception_InvalidCharacter = "Invalid character type \"{0}\"!";
        public static string Exception_InvalidItem = "Invalid item type \"{0}\"!";
        public static string Exception_CharacterNotFound = "Character {0} not found!";
        public static string Exception_NoItemsInPool = "No items left in pool!";

        /// <summary>
        /// "{attackerName} cannot attack!"
        /// </summary>
        public static string Exception_IsWarrior = "{0} cannot attack!";

        /// <summary>
        /// "{healerName} cannot heal!"
        /// </summary>
        public static string Exception_IsCleric = "{0} cannot heal!";
    }
}
