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
        public static string format = "dd/MM/yyyy";
        public static void Main()
        {
            members = new List<FamilyMember>();

            string search = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(new char[] { '-' },
                    StringSplitOptions.RemoveEmptyEntries);

                FamilyMember member1;
                FamilyMember member2;

                if (tokens.Length > 1)
                {
                    Parser(tokens[0], out member1);
                    Parser(tokens[1], out member2);

                    member1.Children.Add(member2);
                    member2.Parents.Add(member1);
                }
                else
                {
                    string[] info = tokens[0].Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                    Parser(info[0] + " " + info[1], out member1);
                    Parser(info[2], out member1);
                }
            }

            FamilyMember member = members.FirstOrDefault(
                m => m.Name == search);
            Console.WriteLine(member);
            Console.WriteLine("Parents:");
            member.Parents.ForEach(p => Console.WriteLine(p));
            Console.WriteLine("Children:");
            member.Children.ForEach(c => Console.WriteLine(c));

        }

        private static void Parser(string input, out FamilyMember member)
        {
            member = members.FirstOrDefault(
                m => m.Birthday == input || m.Name == input);

            if (member == null)
            {
                member = new FamilyMember();
                members.Add(member);
            }

            if (input.Any(Char.IsDigit) && member.Birthday == null)
            {
                member.Birthday = input;
            }
            else if (member.Name == null)
            {
                member.Name = input;
            }
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
