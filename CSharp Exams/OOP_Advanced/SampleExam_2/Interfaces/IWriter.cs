public interface IWriter
{
    void WriteLine(string line);
    void WriteLine(string format, params string[] args);
}