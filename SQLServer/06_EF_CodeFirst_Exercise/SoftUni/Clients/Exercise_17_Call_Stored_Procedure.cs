namespace SoftUni.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using System.Data.SqlClient;

    class Exercise_17_Call_Stored_Procedure
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Trim()
                .Split()
                .ToArray();
            var firstParam = new SqlParameter("@firstName", input[0]);
            var lastParam = new SqlParameter("@lastName", input[1]);
            
            var result = new List<Project>();
            using (var context = new SoftUniContext())
            {
                result = context.Database
                    .SqlQuery<Project>("AllProjects @firstName, @lastName",
                        firstParam, lastParam)
                    .ToList();
            }

            result.ForEach(p => Console.WriteLine($"{p.Name} - {p.Description} - {p.StartDate}"));
        }
    }
}
