

namespace Introduction_DB_Apps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;

    class Intro_Insert
    {
        static void Main()
        {
            Console.Write("Town Name: ");
            string townName = Console.ReadLine();

            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=SoftUni;
Integrated Security=true;
");
            dbConn.Open();

            /*
            using (dbConn)
            {
                string query = $@"
INSERT INTO Towns
VALUES('{townName}')";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                int affected = cmd.ExecuteNonQuery();
                Console.WriteLine("Affected: {0} rows", affected);
            }
            */

            using (dbConn)
            {
                string query = "INSERT INTO Towns VALUES(@TownName)";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                cmd.Parameters.AddWithValue("@TownName", townName);
                int affected = cmd.ExecuteNonQuery();
                Console.WriteLine("Affected: {0} rows", affected);
            }
        }
    }
}
