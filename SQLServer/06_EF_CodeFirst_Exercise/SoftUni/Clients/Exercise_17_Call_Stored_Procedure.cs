namespace SoftUni.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    class Exercise_17_Call_Stored_Procedure
    {
        static void Main()
        {
            var context = new SoftUniContext();
            var result = context.AllProjects("Ruth", "Ellerbrock");
            result.ForEach(p => Console.WriteLine($"{p.Name} - {p.Description} - {p.StartDate}"));

        }
    }
}
