namespace BashSoft_OOP.Interface
{
    public interface ICommandInterpreter
    {
        IExecutable Interpreter(string[] arguments);
    }
}
