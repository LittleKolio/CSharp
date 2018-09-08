namespace University.Data
{
    using Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;

    public class Init
    {
        public static void Initializer()
        {
            UniversityContext context = new UniversityContext();
            using (context)
            {
                context.Database.Initialize(true);
                ImportStudents(context);
            }
        }

        private static void ImportStudents(UniversityContext context)
        {
            string studentsJson = File.ReadAllText(@"../../Import/students.json");
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(studentsJson);
            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}
