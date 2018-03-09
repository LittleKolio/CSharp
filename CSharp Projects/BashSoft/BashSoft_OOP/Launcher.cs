namespace BashSoft_OOP
{
    public class Launcher
    {
        public static void Main()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter(
                new StudentsRepository(),
                new IOManager(),
                new RepositoryFilter(),
                new RepositorySorter()
                );

            InputReader inputReader = new InputReader(commandInterpreter);

            inputReader.StartReadingCommands();
        }
    }
}
