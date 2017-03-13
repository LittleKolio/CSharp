namespace Introduction_DB_Apps_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_06_Remove_Villain
    {
        static void Main()
        {
            Console.Write("Villain Id: ");
            int input = int.Parse(Console.ReadLine());

            string villainName = "";
            int minions = 0;

            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=MinionsDB;
Integrated Security=true;");

            //query for trigger by villain Id
            string query_TriggerDeleteVillain = File.ReadAllText("../../trigger_DeleteVillains_exercise_6.sql");

            //query for search by villain Id
            string query_GetVillain = File.ReadAllText("../../VillainInfo_exercise_6.sql");

            //query for delete by villain Id -> activate trigger
            string query_DeleteVillain = "delete from Villains where Id = @VillainId";

            dbConn.Open();
            using (dbConn)
            {
                SqlCommand cmd_TriggerDeleteVillain = new SqlCommand(query_TriggerDeleteVillain, dbConn);
                TriggerWrapper(cmd_TriggerDeleteVillain);

                SqlCommand cmd_GetVillain = new SqlCommand(query_GetVillain, dbConn);
                cmd_GetVillain.Parameters.AddWithValue("@VillainId", input);

                SqlDataReader reader_GetVillain = cmd_GetVillain.ExecuteReader();
                using (reader_GetVillain)
                {
                    if (!reader_GetVillain.HasRows)
                    {
                        Console.WriteLine("There's no villain with Id " + input + " in database.");
                        return;
                    }
                    else
                    {
                        reader_GetVillain.Read();
                        //Console.WriteLine(reader_GetVillain["VillainName"]);
                        //Console.WriteLine(reader_GetVillain["Minions"]);

                        villainName = (string)reader_GetVillain["VillainName"];
                        minions = (int)reader_GetVillain["Minions"];
                    }
                }

                SqlCommand cmd_DeleteVillain = new SqlCommand(query_DeleteVillain, dbConn);
                cmd_DeleteVillain.Parameters.AddWithValue("@VillainId", input);
                try
                {
                    cmd_DeleteVillain.ExecuteNonQuery();
                    Console.WriteLine(villainName + " was deleted");
                    Console.WriteLine(minions + " minions released");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void TriggerWrapper(SqlCommand cmd_TriggerDeleteVillain)
        {
            try
            {
                cmd_TriggerDeleteVillain.ExecuteNonQuery();
                Console.WriteLine("Delete trigger created.");
            }
            catch (SqlException ex)
            {
                //Console.WriteLine(ex.Message);
            }
            return;
        }
    }
}
