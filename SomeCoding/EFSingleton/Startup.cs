namespace EFSingleton
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            InsertServices();

            string str = "f this curs ... AAAAAAAA";
            //var n = ServiceLocator.Instance.GetService("music");
            //var n = ServiceLocator.Instance.GetService("banana");
            var n = ServiceLocator.Instance.GetServiceConfig();

            n.Print(str);
        }

        static void InsertServices()
        {
            ServiceLocator.Instance.AddService("music", new ChildOne());
            ServiceLocator.Instance.AddService("banana", new ChildTwo());
        }
    }
}
