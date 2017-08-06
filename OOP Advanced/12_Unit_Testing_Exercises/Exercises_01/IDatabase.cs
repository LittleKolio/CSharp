public interface IDatabase
{
    int Count { get; }
    void Add(int element);
    void Remove();
    int[] Fech();
}