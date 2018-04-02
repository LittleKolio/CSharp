namespace Exercise_07_Inferno_Infinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponType, string[] args);
    }
}
