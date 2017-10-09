using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Commands
{
    public abstract class Command
    {
        protected List<string> list;

        public Command(List<string> list)
        {
            this.list = list;
        }

        public abstract void Execute();
        public abstract Command Create(List<string> list);
    }
}
