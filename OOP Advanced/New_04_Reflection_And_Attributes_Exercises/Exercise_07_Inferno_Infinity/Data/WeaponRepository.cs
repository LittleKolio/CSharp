namespace Exercise_07_Inferno_Infinity.Data
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WeaponRepository : IRepository
    {
        private IList<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        private IWeapon Exist(string weaponName, string weaponType)
        {
            return this.weapons
                .FirstOrDefault(w => w.Name == weaponName &&
                    w.GetType().Name == weaponType);
        }

        public void AddWeapon(IWeapon weapon)
        {
            IWeapon weaponInList = this.Exist(weapon.Name, weapon.GetType().Name);
            if (weaponInList != null)
            {
                throw new InvalidOperationException(
                    "Weapon ALREADY exist!");
            }

            this.weapons.Add(weapon);
        }

        public IWeapon GetWeapon(string weaponType, string weaponName)
        {
            IWeapon weaponInList = this.Exist(weaponName, weaponType);
            if (weaponInList == null)
            {
                throw new InvalidOperationException(
                    "Weapon DON'T exist!");
            }

            return weaponInList;
        }
    }
}
