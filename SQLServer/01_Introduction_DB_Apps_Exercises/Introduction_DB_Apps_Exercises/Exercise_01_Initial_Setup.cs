namespace Introduction_DB_Apps_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_01_Initial_Setup
    {
        static void Main()
        {
            //CreateDatabase();

            //string query = File.ReadAllText("../../CreateTables_exercise_1.sql");
            //string query = File.ReadAllText("../../InsertValues_exercise_1.sql");
            //Create(query);

        }

        private static void Create(string query)
        {
            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=MinionsDB;
Integrated Security=true;");
            SqlCommand cmd = new SqlCommand(query, dbConn);

            dbConn.Open();
            using (dbConn)
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static void CreateDatabase()
        {
            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Integrated Security=true;");
            string query = "CREATE DATABASE MinionsDB";
            SqlCommand cmd = new SqlCommand(query, dbConn);

            dbConn.Open();
            using (dbConn)
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
