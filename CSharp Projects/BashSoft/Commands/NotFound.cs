namespace BashSoft.Commands
{
    using IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NotFound : ICommand
    {
        public NotFound(string input)
        {
            this.Input = input;
        }

        public string Input { get; set; }

        public void Execute()
        {
            OutputWriter.WriteOneLineMessage(
                $"Command: {this.Input} not found!");
        }
    }
}
