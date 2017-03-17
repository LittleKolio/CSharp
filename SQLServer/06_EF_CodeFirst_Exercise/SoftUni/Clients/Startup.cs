namespace SoftUni.Clients
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();
            var result = context.AllProjects("Ruth", "Ellerbrock");
            result.ForEach(p => Console.WriteLine($"{p.Name} - {p.Description} - {p.StartDate}"));
        }
    }
}
