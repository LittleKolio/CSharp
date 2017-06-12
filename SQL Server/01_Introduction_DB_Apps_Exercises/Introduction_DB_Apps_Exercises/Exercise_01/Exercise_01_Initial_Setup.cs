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
            //1. Create DB
            //CreateDatabase();

            //2. Create Tables
            //string query = File.ReadAllText(
            //"../../Exercise_01/Exercise_01_CreateTables.sql");
            //Create(query);

            //3. Insert Values
            //string query = File.ReadAllText(
            //    "../../Exercise_01/Exercise_01_InsertValues.sql");
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
