namespace SoftUniADO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    class Exercise_03_Employees_Full_Information
    {
        static void Main()
        {
            //FileStream ostrm;
            //StreamWriter writer;
            //TextWriter oldOut = Console.Out;
            //try
            //{
            //    ostrm = new FileStream("../../Exercise_03_Employees_Full_Information.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //    writer = new StreamWriter(ostrm);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Cannot open Redirect.txt for writing");
            //    Console.WriteLine(e.Message);
            //    return;
            //}
            //Console.SetOut(writer);

            var context = new SoftUniEntities();
            var employees = context.Employees;

            foreach (var e in employees)
            {
                Console.Write(e.FirstName);
                Console.Write(" " + e.LastName);
                Console.Write(" " + e.MiddleName);
                Console.Write(" " + e.JobTitle);
                Console.Write(" " + e.Salary);
                Console.WriteLine();
            }

            //Console.SetOut(oldOut);
            //writer.Close();
            //ostrm.Close();

        }
    }
}
