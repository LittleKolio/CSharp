namespace Exercise_07_Inferno_Infinity.Contracts
{
    public interface IRepository
    {
        void AddWeapon(IWeapon weapon);
        IWeapon GetWeapon(string weaponType, string weaponName);
    }
}
