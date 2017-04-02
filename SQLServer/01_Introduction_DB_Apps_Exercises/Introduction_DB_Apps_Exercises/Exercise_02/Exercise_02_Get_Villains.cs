namespace Introduction_DB_Apps_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_02_Get_Villains
    {
        static void Main()
        {
            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=MinionsDB;
Integrated Security=true;");

            string query = File.ReadAllText("../../Exercise_02/Exercise_02_SelectVillains.sql");
            SqlCommand cmd = new SqlCommand(query, dbConn);

            dbConn.Open();
            using (dbConn)
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
            }
        }
    }
}
