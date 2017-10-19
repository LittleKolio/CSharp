namespace BashSoft.Commands
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestCommand : ICommand
    {
        public TestCommand(string test)
        {
            this.Test = test;
        }

        public string Test { get; set; }

        public void Execute()
        {
            OutputWriter.WriteOneLineMessage("Command: test - " + this.Test);
        }
    }
}
