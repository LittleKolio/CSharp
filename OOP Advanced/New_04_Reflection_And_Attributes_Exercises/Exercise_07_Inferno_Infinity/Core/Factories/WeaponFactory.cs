namespace Exercise_07_Inferno_Infinity.Core.Factories
{
    using Contracts;
    using Models;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string[] data)
        {
            string weaponType = data[0];
            string weaponName = data[1];
            string weaponRarity = data[2];

            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == weaponType);

            if (type == null)
            {
                throw new ArgumentException(
                    "Invalid WeaponType!");
            }

            Rarity rarity;
            if (!Enum.TryParse<Rarity>(weaponRarity, out rarity))
            {
                throw new ArgumentException(
                    "Invalid WeaponRarity!");
            }

            object[] parameters = new object[] { weaponName, rarity };

            if (!typeof(IWeapon).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(
                    "WeaponType don't inherit IWeapon!");
            }

            IWeapon weapon = (IWeapon)Activator.CreateInstance(type, parameters);

            return weapon;
        }
    }
}
