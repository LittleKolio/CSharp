
namespace Exercise_02_Kings_Gambit.Contracts
{
    using System.Collections.Generic;

    public delegate void GetAttackedEventHandler(object sub);

    public interface IKing : INameable
    {
        event GetAttackedEventHandler GetAttackedEvent;
        IReadOnlyCollection<ISubordinate> Subordinates { get; }
        void AddSubordinates(ISubordinate sub);
        void Attacked();
    }
}
