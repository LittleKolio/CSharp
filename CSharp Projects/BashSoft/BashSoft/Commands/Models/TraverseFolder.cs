namespace BashSoft.Commands
{
    using BashSoft.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Cmd(CmdEnum.ls)]
    public class TraverseFolder : ICmd
    {
        private int depth;

        public TraverseFolder(int depth)
        {
            this.depth = Depth;
        }

        public int Depth
        {
            get { return this.depth; }
            set { this.depth = value; }
        }

        public void Execute()
        {
            IOManager.TraverseFolder(this.Depth);
        }
    }
}
