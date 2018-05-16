namespace BashSoft_OOP.Core.Interfaces
{
    public interface ICommandInterpreter
    {
        IExecutable Interpreter(string[] arguments);
    }
}
