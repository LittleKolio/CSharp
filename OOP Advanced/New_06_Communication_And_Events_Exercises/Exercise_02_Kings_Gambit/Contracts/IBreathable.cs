namespace Exercise_02_Kings_Gambit.Contracts
{
    public interface IBreathable
    {
        bool IsAlive { get; }
        void Die();
    }
}
