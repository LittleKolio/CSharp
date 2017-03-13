namespace Introduction_DB_Apps_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_03_Get_Minion_Names
    {
        static void Main()
        {
            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=MinionsDB;
Integrated Security=true;");

            Console.Write("Villain Id: ");
            int villainId = int.Parse(Console.ReadLine());
            string query = File.ReadAllText("../../VillainInfo_exercise_3.sql");

            dbConn.Open();
            using (dbConn)
            {

                SqlCommand cmd = new SqlCommand(query, dbConn);
                cmd.Parameters.AddWithValue("@VillainId", villainId);
                SqlDataReader reader = cmd.ExecuteReader();

                //string villainName = (string)cmd.ExecuteScalar();
                //if (villainName == null) { }

                if (!reader.HasRows)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                    //Console.WriteLine($"Villain: {villainName}");
                    //SqlDataReader reader = cmd.ExecuteReader();

                    int count = 1;
                    while (reader.Read())
                    {
                        if (count == 1)
                        {
                            Console.WriteLine($"Villain: {reader[0]}");
                        }
                        if (reader[1] == System.DBNull.Value ||
                            reader[2] == System.DBNull.Value)
                        {
                            Console.WriteLine("(no minions)");
                            break;
                        }
                        Console.WriteLine($"{count}. {reader[1]} {reader[2]}");
                        count++;
                    }
                }
            }
        }
    }
}
