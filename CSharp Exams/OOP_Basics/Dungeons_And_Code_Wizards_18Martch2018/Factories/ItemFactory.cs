namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            switch (type)
            {
                case "ArmorRepairKit": return new ArmorRepairKit();
                case "PoisonPotion": return new PoisonPotion();
                case "HealthPotion": return new HealthPotion();
                default:
                    throw new ArgumentException(
                        string.Format(Constants.Exception_InvalidItem, type));
            }
        }
    }
}
