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

        public Command()
        {
        }

        public Command(List<string> list)
        {
            this.List = list;
        }

        public virtual List<string> List
        {
            get { return this.list; }
            protected set { this.list = value; }
        }

        public abstract void Execute();
        public abstract Command Create(List<string> list);
    }
}
