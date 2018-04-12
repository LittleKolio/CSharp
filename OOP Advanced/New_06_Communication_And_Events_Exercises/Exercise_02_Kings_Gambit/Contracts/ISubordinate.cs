namespace Exercise_02_Kings_Gambit.Contracts
{
    public interface ISubordinate : INameable, IBreathable
    {
        string Action { get; }
        int Hits { get; }
        void ReactToAttack();
        void TakeHit();
    }
}
