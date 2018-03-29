namespace Exercise_03_Stack
{
    public interface ICustomStack<T>
    {
        void Push(params T[] args);
        T Pop();
    }
}