namespace Introduction_DB_Apps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;

    class Project_Menager
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=SoftUni;
Integrated Security=true;");

            connection.Open();

            using (connection)
            {
                while (true)
                {
                    Console.Write("Enter command: ");
                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "list": PrintAllProjects(connection); break;
                        case "details": ShowDetails(connection); break;
                        case "search": SearchByName(connection); break;
                        case "exit": return;
                    }
                }
            }
        }

        private static void PrintAllProjects(SqlConnection connection)
        {

            string query = "SELECT ProjectId, Name FROM Projects";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                Console.WriteLine(" ID | Project Name");
                Console.WriteLine("----+--------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0],4}| {reader[1]}");
                }
            }
        }

        private static void ShowDetails(SqlConnection connection)
        {
            Console.Write("Enter ID: ");
            int projectId = int.Parse(Console.ReadLine());

            string query = "SELECT * FROM Projects WHERE ProjectId = @ProjectId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectId", projectId);
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                if (!reader.Read())
                {
                    Console.WriteLine("Project not found");
                    return;
                }

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.WriteLine(reader.GetName(i));
                    Console.WriteLine(new string('-', 15));
                    Console.WriteLine(reader[i]);
                    Console.WriteLine();
                }
            }

            string query2 = @"
SELECT e.EmployeeId, e.FirstName, e.LastName
FROM Employees AS e
JOIN EmployeesProjects AS ep
    ON ep.EmployeeId = e.EmployeeId
    AND ep.ProjectId = @ProjectId";
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            cmd2.Parameters.AddWithValue("@ProjectId", projectId);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (!reader2.HasRows)
            {
                Console.WriteLine("No employees");
            }
            else
            {
                using (reader2)
                {
                    while (reader2.Read())
                    {
                        Console.WriteLine($"{reader2[0],4}| {reader2[1]} {reader2[2]}");
                    }
                }
            }
        }

        /*
        private static void SearchByName(SqlConnection connection)
        {
            Console.Write("Enter search criteria: ");
            string pattern = Console.ReadLine();

            string query = @"
SELECT TOP 1 ProjectId
FROM Projects
WHERE Name LIKE @ProjectName";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectName", "%" + pattern + "%");
            int result = (int?)cmd.ExecuteScalar() ?? -1; // ?? what the f
            if (result < 0)
            {
                Console.WriteLine("Project not found");
                return;
            }
            Console.WriteLine($"Found project with ID: {result}");
        }
        */

        private static void SearchByName(SqlConnection connection)
        {
            Console.Write("Enter search criteria: ");
            string pattern = Console.ReadLine();

            string query = @"
SELECT ProjectId
FROM Projects
WHERE Name LIKE @ProjectName";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProjectName", "%" + pattern + "%");
            SqlDataReader result = cmd.ExecuteReader();

            if (!result.HasRows)
            {
                Console.WriteLine("Project not found");
                return;
            }
            using (result)
            {
                List<string> list = new List<string>();
                while (result.Read())
                {
                    list.Add(result[0].ToString());
                }
                Console.WriteLine($"Found project with ID: {string.Join(", ", list)}");
            }
        }
    }
}
