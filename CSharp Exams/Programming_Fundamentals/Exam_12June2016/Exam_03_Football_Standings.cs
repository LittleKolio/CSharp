using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_12June2016
{
    class Exam_03_Football_Standings
    {
        static void Main()
        {


            string delim = Console.ReadLine();

            Dictionary<string, int> teamGoals = new Dictionary<string, int>();
            Dictionary<string, int> teamPoints = new Dictionary<string, int>();


            while (true)
            {
                string text = Console.ReadLine();
                if (text == "final")
                    break;
                int l = text.Length;
                int teamAGoals = int.Parse(text[l - 3].ToString());
                int teamBGoals = int.Parse(text[l - 1].ToString());


                string[] newText = Split(text, delim);
                string teamA = newText[0];
                string teamB = newText[1];
                //Console.WriteLine (teamA);
                //Console.WriteLine (teamB);
                //Console.WriteLine (teamAG);
                //Console.WriteLine (teamBG);
                int a = 0;
                int b = 0;
                if (teamAGoals > teamBGoals)
                    a = 3;
                else if (teamAGoals == teamBGoals)
                {
                    a = 1;
                    b = 1;
                }
                else if (teamAGoals < teamBGoals)
                    b = 3;
                if (teamPoints.ContainsKey(teamA))
                {
                    teamPoints[teamA] += a;
                    teamGoals[teamA] += teamAGoals;
                }
                else
                {
                    teamPoints.Add(teamA, a);
                    teamGoals.Add(teamA, teamAGoals);
                }
                if (teamPoints.ContainsKey(teamB))
                {
                    teamPoints[teamB] += b;
                    teamGoals[teamB] += teamBGoals;
                }
                else
                {
                    teamPoints.Add(teamB, b);
                    teamGoals.Add(teamB, teamBGoals);
                }


            }
            List<KeyValuePair<string, int>> sortedTeamPoints = teamPoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToList();
            Console.WriteLine("League standings:");
            int count = 0;
            foreach (var item in sortedTeamPoints)
            {
                count++;
                Console.WriteLine("{0}. {1} {2}", count, item.Key, item.Value);
            }
            List<KeyValuePair<string, int>> sortedTeamGoals = teamGoals
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(3)
                .ToList();
            Console.WriteLine("Top 3 scored goals:");
            foreach (var item in sortedTeamGoals)
            {
                Console.WriteLine("- {0} -> {1}", item.Key, item.Value);
            }
        }

        static string[] Split(string text, string delim)
        {
            string[] newText = new string[2];
            int l = delim.Length;
            int start = 0;
            for (int i = 0; i < 2; i++)
            {
                int index1 = text.IndexOf(delim, start);
                int index2 = text.IndexOf(delim, index1 + l);
                newText[i] = string.Join(string.Empty, text
                    .Substring(index1 + l, index2 - (index1 + l))
                    .ToUpper()
                    .Reverse()
                    .ToArray()
                );
                start = index2 + l;
            }
            return newText;
        }
    }
}
