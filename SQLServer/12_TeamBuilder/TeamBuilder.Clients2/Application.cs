namespace TeamBuilder.Clients2
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utilities;

    class Application
    {
        static void Main(string[] args)
        {
            //Init.Initializer();

            var swr = new Switcher();
            var ctr = new Controller(swr);
            ctr.Run();
        }
    }
}
