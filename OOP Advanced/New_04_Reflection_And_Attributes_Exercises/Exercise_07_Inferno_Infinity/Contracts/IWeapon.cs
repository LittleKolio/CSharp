namespace Exercise_07_Inferno_Infinity.Contracts
{
    public interface IWeapon
    {
        void Add(IMagicalStats gem, int socket);
        void Remove(int socket);
    }
}
