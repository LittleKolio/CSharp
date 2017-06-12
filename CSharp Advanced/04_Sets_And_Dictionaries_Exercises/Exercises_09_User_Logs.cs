using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_And_Dictionaries_Exercises
{
    class Exercises_09_User_Logs
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, int>> users 
                = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ');

                if (input[0] == "end") { break; }

                string ip = input[0].Replace("IP=", string.Empty);
                string username = input[2].Replace("user=", string.Empty);

                ///Test
                //Console.WriteLine($"{username} -> {ip}");

                if (!users.ContainsKey(username))
                {
                    users.Add(
                        username, 
                        new Dictionary<string, int> { { ip, 1} });
                }
                else
                {
                    if (!users[username].ContainsKey(ip))
                    {
                        users[username].Add(ip, 0);
                    }
                    users[username][ip]++;
                }
            }

            PrintUsers(users);
        }

        private static void PrintUsers(
            Dictionary<string, Dictionary<string, int>> users)
        {
            foreach (var user in users.OrderBy(e => e.Key))
            {
                Console.WriteLine($"{user.Key}: ");
                Console.WriteLine("{0}.", 
                    string.Join(", ", user.Value.Select(
                        e => $"{e.Key} => {e.Value}")));
            }
        }
    }
}
