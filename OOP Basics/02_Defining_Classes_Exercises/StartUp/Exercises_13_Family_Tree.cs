namespace Defining_Classes_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_13_Family_Tree
    {
        public static List<FamilyMember> members;

        public static void Main()
        {
            members = new List<FamilyMember>();

            string search = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(new char[] { '-' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => t.Trim())
                    .ToArray();

                if (tokens.Length > 1)
                {
                    FamilyMember member1 = Find(tokens[0]);
                    FamilyMember member2 = Find(tokens[1]);

                    member1.Children.Add(member2);
                    member2.Parents.Add(member1);
                }
                else
                {
                    string[] info = tokens[0].Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                    string date = info[2];
                    string name = info[0] + " " + info[1];
                    Dublicate(name, date);
                }
            }

            FamilyMember member = members.FirstOrDefault(
                m => m.Name == search || m.Birthday == search);
            Console.WriteLine(member);
            Console.WriteLine("Parents:");
            member.Parents.ForEach(p => Console.WriteLine(p));
            Console.WriteLine("Children:");
            member.Children.ForEach(c => Console.WriteLine(c));

        }

        private static FamilyMember Combine(FamilyMember[] dublicate)
        {
            FamilyMember member1 = dublicate[0];
            FamilyMember member2 = dublicate[1];

            member1.Children.AddRange(member2.Children);
            member2.Children = null;
            member1.Parents.AddRange(member2.Parents);
            member2.Parents = null;

            members.Remove(member2);

            return member1;
        }

        private static void Dublicate(string name, string date)
        {
            FamilyMember[] dublicate = members
                .Where(m => m.Birthday == date || m.Name == name)
                .ToArray();

            FamilyMember member;

            if (dublicate.Length == 0)
            {
                member = new FamilyMember();
                members.Add(member);
            }
            else if (dublicate.Length == 1)
            {
                member = dublicate[0];
            }
            else
            {
                member = Combine(dublicate);
            }

            if (member.Birthday == null)
            {
                member.Birthday = date;
            }
            if (member.Name == null)
            {
                member.Name = name;
            }
        }

        private static FamilyMember Find(string input)
        {
            FamilyMember member = members
                .FirstOrDefault(m => m.Birthday == input || m.Name == input);

            if (member == null)
            {
                member = new FamilyMember();
                members.Add(member);
            }

            if (input.Any(Char.IsDigit))
            {
                if (member.Birthday == null)
                {
                    member.Birthday = input;
                }
            }
            else if (member.Name == null)
            {
                member.Name = input;
            }

            return member;

        }

        //private static bool Parser(string input, out DateTime birthday)
        //{
        //    return DateTime.TryParseExact(
        //        input, "dd/MM/yyyy", 
        //        CultureInfo.InvariantCulture,
        //        DateTimeStyles.None,
        //        out birthday);
        //}
    }
}
