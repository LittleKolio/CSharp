namespace TeamBuilder.Clients2.Utilities
{
    using System;

    public class Controller
    {
        private Switcher cmdSwitch;
        public Controller(Switcher cmdSwitch)
        {
            this.cmdSwitch = cmdSwitch;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    var inputParam = Console.ReadLine();
                    var result = this.cmdSwitch.GetCommand(inputParam);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException().Message);
                }
            }
        }
    }
}
