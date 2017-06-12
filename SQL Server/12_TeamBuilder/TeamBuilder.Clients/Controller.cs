namespace TeamBuilder.Clients
{
    using System;
    using System.Runtime.InteropServices;

    public class Controller
    {
        private Switcher cmdSwitcher;
        public Controller(Switcher cmdSwitcher)
        {
            this.cmdSwitcher = cmdSwitcher;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    var inputParam = Console.ReadLine()
                        .Split(new char[] { ' ', '\t' },
                            StringSplitOptions.RemoveEmptyEntries);

                    var stringResult = this.cmdSwitcher
                        .GetCommand(inputParam)
                        .CmdExecution();

                    Console.WriteLine(stringResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException().Message);
                }
            }
        }
    }
}
