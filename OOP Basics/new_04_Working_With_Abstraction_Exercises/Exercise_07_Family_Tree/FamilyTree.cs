namespace Exercise_07_Family_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FamilyTree
    {
        public static List<FamilyMember> members;

        static void Main(string[] args)
        {
            members = new List<FamilyMember>();

            string search = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input.Contains("-"))
                {
                    Conection(input);
                }
                else
                {
                    CreateMember(input);
                }
            }
        }

        private static void CreateMember(string input)
        {
            string[] tokens = SplitInput(input, " ");

            string name = tokens[0] + " " + tokens[1];
            DateTime birthday;
            Parser(tokens[2], out birthday);

            FamilyMember memWithBirthday = members.FirstOrDefault(m => m.Birthday == birthday);
            FamilyMember memWithName = members.FirstOrDefault(m => m.Name == name);

            if (memWithBirthday == null && memWithName == null)
            {
                FamilyMember member = new FamilyMember();
                member.Birthday = birthday;
                member.Name = name;
                members.Add(member);
            }
            else if (memWithBirthday == null)
            {
                memWithName.Birthday = birthday;
            }
            else if (memWithName == null)
            {
                memWithName.Name = name;
            }
            else
            {

            }
        }

        private static void Conection(string input)
        {
            string[] tokens = SplitInput(input, "-").Select(t => t.Trim()).ToArray();
            FamilyMember[] temp = new FamilyMember [tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                FamilyMember member;
                DateTime birthday;
                if (Parser(tokens[i], out birthday))
                {
                    member = members.FirstOrDefault(m => m.Birthday == birthday);
                    if (member == null)
                    {
                        member = new FamilyMember();
                        member.Birthday = birthday;
                        members.Add(member);
                    }
                }
                else
                {
                    member = members.FirstOrDefault(m => m.Name == tokens[i]);
                    if (member == null)
                    {
                        member = new FamilyMember();
                        member.Name = tokens[i];
                        members.Add(member);
                    }
                }

                temp[i] = member;
            }

            temp[0].Children.Add(temp[1]);
            temp[1].Parents.Add(temp[0]);
        }

        private static bool Parser(string input, out DateTime birthday)
        {
            return DateTime.TryParseExact(
                input, "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out birthday);
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                   StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
