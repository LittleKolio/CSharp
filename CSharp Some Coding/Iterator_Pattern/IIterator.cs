namespace IteratorPattern
{
    public interface IIterator
    {
        void First();
        void Last();
        void Next();
        void Previous();
        object Current();
        bool IsDone();
    }
}
