using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Commands
{
    public abstract class Command
    {
        private List<string> list;

        public Command(List<string> list)
        {
            this.List = list;
        }

        protected List<string> List
        {
            get { return this.list; }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Nothing!!");
                }
                this.list = value;
            }
        }

        public abstract void Execute();
        public abstract Command Create(List<string> list);
    }
}
