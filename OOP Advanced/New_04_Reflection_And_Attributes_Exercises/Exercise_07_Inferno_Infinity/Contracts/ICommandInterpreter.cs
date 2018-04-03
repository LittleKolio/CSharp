namespace Exercise_07_Inferno_Infinity.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data);
    }
}
