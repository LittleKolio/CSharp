namespace Exercise_07_Inferno_Infinity.Core.Factories
{
    using Contracts;
    using Models;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string[] args)
        {
            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == weaponType);

            if (type == null)
            {
                throw new ArgumentException(
                    "Invalid WeaponType!");
            }

            string weaponName = args[0];

            Rarity weaponRarity;
            if (!Enum.TryParse<Rarity>(args[1], out weaponRarity))
            {
                throw new ArgumentException(
                    "Invalid WeaponRarity!");
            }

            object[] parameters = new object[] { weaponName, weaponRarity };

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
