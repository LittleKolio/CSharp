namespace Introduction_DB_Apps_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercise_04_Add_Minion
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(": ".ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);
            string[] input2 = Console.ReadLine()
                .Split(": ".ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);

            //for (int i = 0; i < input.Length; i++) { Console.WriteLine(input[i]); }

            //I wanted DB to validate the data which we insert and added triggers to activate instead of insert.
            //Basically i do only insert and triggers handle the rest.
            //Triggers throw message if data exist and i think they implicitly have XACT_ABORT on (for ROLLBACK).
            //I don't have CONSTRAINT UNIQUE(MinionId, VillainId) and checking if villain with minion exist.
            //английския ми е много зле (също както българския)

            SqlConnection dbConn = new SqlConnection(@"
Server=(localdb)\MSSQLLocalDB;
Database=MinionsDB;
Integrated Security=true;");

            // add trigger on Minions instead of insert(throw error message)
            string query_TriggerInsertMinion = File.ReadAllText(
                "../../Exercise_04/Exercise_04_trigger_InsertMinion.sql");
            SqlCommand cmd_TriggerInsertMinion = new SqlCommand(
                query_TriggerInsertMinion, dbConn);

            // add trigger on Towns instead of insert(throw error message)
            string query_TriggerInsertTowns = File.ReadAllText(
                "../../Exercise_04/Exercise_04_trigger_InsertTowns.sql");
            SqlCommand cmd_TriggerInsertTowns = new SqlCommand(
                query_TriggerInsertTowns, dbConn);

            // add trigger on Villains instead of insert(throw error message)
            string query_TriggerInsertVillains = File.ReadAllText(
                "../../Exercise_04/Exercise_04_trigger_InsertVillains.sql");
            SqlCommand cmd_TriggerInsertVillains = new SqlCommand(
                query_TriggerInsertVillains, dbConn);

            // add trigger on MinionsVillains instead of insert(throw error message)
            string query_TriggerInsertMinionsVillains = File.ReadAllText(
                "../../Exercise_04/Exercise_04_trigger_InsertMinionVillain.sql");
            SqlCommand cmd_TriggerInsertMinionVillain = new SqlCommand(
                query_TriggerInsertMinionsVillains, dbConn);


            // 1. insert town -> activate trigger
            string query_InsertTown = File.ReadAllText(
                "../../Exercise_04/Exercise_04_InsertTown.sql");
            SqlCommand cmd_InsertTown = new SqlCommand(
                query_InsertTown, dbConn);
            cmd_InsertTown.Parameters.AddWithValue("@TownName", input[3]);

            // 2. insert minion -> activate trigger
            string query_InsertMinion = File.ReadAllText(
                "../../Exercise_04/Exercise_04_InsertMinion.sql");
            SqlCommand cmd_InsertMinion = new SqlCommand(
                query_InsertMinion, dbConn);
            cmd_InsertMinion.Parameters.AddWithValue("@MinionName", input[1]);
            cmd_InsertMinion.Parameters.AddWithValue("@Age", int.Parse(input[2]));
            cmd_InsertMinion.Parameters.AddWithValue("@TownName", input[3]);

            // 3. insert villain -> activate trigger
            string query_InsertVillain = File.ReadAllText(
                "../../Exercise_04/Exercise_04_InsertVillain.sql");
            SqlCommand cmd_InsertVillain = new SqlCommand(
                query_InsertVillain, dbConn);
            cmd_InsertVillain.Parameters.AddWithValue("@VillainName", input2[1]);

            // 4. insert minion villain -> activate trigger
            string query_InsertMinionVillain = File.ReadAllText(
                "../../Exercise_04/Exercise_04_InsertMinionVillain.sql");
            SqlCommand cmd_InsertMinionVillain = new SqlCommand(
                query_InsertMinionVillain, dbConn);
            cmd_InsertMinionVillain.Parameters.AddWithValue("@MinionName", input[1]);
            cmd_InsertMinionVillain.Parameters.AddWithValue("@VillainName", input2[1]);

            //List<SqlParameter> list_Minion = new List<SqlParameter>()
            //{
            //    new SqlParameter("@Name", input[1]),
            //    new SqlParameter("@Age", int.Parse(input[2])),
            //    new SqlParameter("@TownName", input[3])
            //};
            //cmd_TriggerInsertMinion.Parameters.AddRange(list_Minion.ToArray());

            dbConn.Open();
            using (dbConn)
            {
                TriggerWrapper(
                    cmd_TriggerInsertMinion,
                    cmd_TriggerInsertTowns,
                    cmd_TriggerInsertVillains,
                    cmd_TriggerInsertMinionVillain
                    );

                try
                {
                    cmd_InsertTown.ExecuteNonQuery();
                    Console.WriteLine($"Town {input[3]} was added to the database.");
                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }

                try
                {
                    cmd_InsertMinion.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {input[1]} to the database.");
                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }

                try
                {
                    cmd_InsertVillain.ExecuteNonQuery();
                    Console.WriteLine($"Villain {input2[1]} was added to the database.");
                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }

                try
                {
                    cmd_InsertMinionVillain.ExecuteNonQuery();
                    Console.WriteLine($"Successfully added {input[1]} to be minion of {input2[1]}");
                }
                catch (SqlException ex) { Console.WriteLine(ex.Message); }
            }
        }

        private static void TriggerWrapper(
            SqlCommand cmd_TriggerInsertMinion,
            SqlCommand cmd_TriggerInsertTowns,
            SqlCommand cmd_TriggerInsertVillains,
            SqlCommand cmd_TriggerInsertMinionVillain)
        {
            try
            {
                cmd_TriggerInsertTowns.ExecuteNonQuery();
                cmd_TriggerInsertMinion.ExecuteNonQuery();
                cmd_TriggerInsertVillains.ExecuteNonQuery();
                cmd_TriggerInsertMinionVillain.ExecuteNonQuery();
                Console.WriteLine("Triggers created.");
            }
            catch(SqlException ex)
            {
                //Console.WriteLine(ex.Message);
            }
            return;
        }
    }
}
