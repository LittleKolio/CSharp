namespace Introduction_DB_Apps_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_05_Change_Town_Names_Casing
    {
        static void Main()
        {
            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=MinionsDB;
Integrated Security=true;");

            Console.Write("Country Name: ");
            string input = Console.ReadLine();

            //save the result from - search by country
            List<string> listTowns = new List<string>();

            //query for search by country
            string query_GetTowns = "SELECT * FROM Towns WHERE Country = @CountryName";

            //query for change name to upper by list
            string query_UpdateTown = "UPDATE Towns SET Name = UPPER(@TownName) WHERE Name = @TownName";
                        
            dbConn.Open();
            using (dbConn)
            {
                SqlCommand cmd_GetTowns = new SqlCommand(query_GetTowns, dbConn);
                cmd_GetTowns.Parameters.AddWithValue("@CountryName", input);
                SqlDataReader reader_GetTowns = cmd_GetTowns.ExecuteReader();
                using (reader_GetTowns)
                {
                    while (reader_GetTowns.Read())
                    {
                        //Console.WriteLine(reader_GetTowns["Name"]);
                        string name = (string)reader_GetTowns["Name"];
                        listTowns.Add(name);
                    }
                }

                foreach (string name in listTowns)
                {
                    SqlCommand cmd_UpdateTown = new SqlCommand(query_UpdateTown, dbConn);
                    cmd_UpdateTown.Parameters.AddWithValue("@TownName", name);
                    try
                    {
                        cmd_UpdateTown.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
