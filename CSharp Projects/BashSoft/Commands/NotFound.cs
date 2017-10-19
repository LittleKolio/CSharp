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
        public NotFound(List<string> list) : base(list)
        {
        }

        public override ICommand Create(List<string> list)
        {
            return new NotFound(list);
        }

        public override void Execute()
        {
            OutputWriter.WriteOneLineMessage(
                $"Command: {base.list[0]} not found!");
        }
    }
}
