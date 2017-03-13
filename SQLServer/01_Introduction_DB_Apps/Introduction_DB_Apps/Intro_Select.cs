namespace Introduction_DB_Apps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;

    class Intro_Select
    {
        static void Main()
        {
            //https://www.connectionstrings.com/sql-server-2012/
            //https://www.connectionstrings.com/sql-server-2008/

            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=SoftUni;
Integrated Security=true;
");
            //SelectOne(dbConn);

            //SelectAll(dbConn);

            //SelectColumn(dbConn);

            //SelectAllFormat(dbConn);

        }

        private static void SelectAllFormat(SqlConnection dbConn)
        {
            dbConn.Open();

            using (dbConn)
            {
                //                string query = $@"
                //SELECT FirstName, LastName, Salary
                //FROM Employees
                //WHERE EmployeeID = {someVar}";

                string query = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string fName = (string)reader["FirstName"];
                        string lName = (string)reader["LastName"];
                        decimal salary = (decimal)reader["Salary"];

                        Console.WriteLine("{0} {1} - {2}", fName, lName, salary);
                    }
                }
            }
        }

        private static void SelectColumn(SqlConnection dbConn)
        {
            dbConn.Open();

            using (dbConn)
            {
                string query = @"
SELECT FirstName, LastName, Salary
FROM Employees";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    //reader.GetInt32

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader.GetName(i),-15}");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i],-15}");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void SelectAll(SqlConnection dbConn)
        {
            dbConn.Open();

            using (dbConn)
            {
                string query = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    //Read връща bool (true/false)
                    //reader.Read();
                    //Console.WriteLine(reader[1]);
                    //reader.Read();
                    //Console.WriteLine(reader[1]);

                    while (reader.Read())
                    {
                        //Console.WriteLine($"Name: {reader[1]} {reader[2]}");

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void SelectOne(SqlConnection dbConn)
        {
            dbConn.Open();

            using (dbConn)
            {
                string query = "SELECT COUNT(*) FROM Employees";
                SqlCommand cmd = new SqlCommand(query, dbConn);
                int result = (int)cmd.ExecuteScalar();

                Console.WriteLine("Number of employees {0}", result);
                Console.WriteLine("Number of employees {0}", cmd.ExecuteScalar());
            }
        }
    }
}
