namespace Exercise_03_BarracksWars_A_New_Factory.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }
}
