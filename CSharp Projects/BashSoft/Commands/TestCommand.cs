namespace BashSoft.Commands
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestCommand : Command
    {
        public TestCommand()
        {
        }

        public TestCommand(List<string> list) : base(list)
        {
        }

        public override Command Create(List<string> list)
        {
            return new TestCommand(list);
        }

        public override List<string> List
        {
            get
            {
                return base.List;
            }

            protected set
            {
                if (value.Count < 2)
                {
                    throw new ArgumentException("List is empty!");
                }
                base.List = value;
            }
        }

        public override void Execute()
        {
            OutputWriter.WriteOneLineMessage("Command: test - " + base.list[1]);
        }
    }
}
