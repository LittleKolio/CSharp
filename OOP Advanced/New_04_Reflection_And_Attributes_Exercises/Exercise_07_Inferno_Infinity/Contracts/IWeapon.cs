namespace Exercise_07_Inferno_Infinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }
        void AddGem(IMagicalStats gem, int socket);
        void RemoveGem(int socket);
    }
}
