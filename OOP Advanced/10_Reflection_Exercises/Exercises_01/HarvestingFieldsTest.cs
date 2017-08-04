namespace Reflection_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type harvesting = typeof(HarvestingFields);
            FieldInfo[] fields = harvesting.GetFields(
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static
                );

            Dictionary<string, Func<FieldInfo[]>> filter = new Dictionary<string, Func<FieldInfo[]>>()
            {
                { "private", () => fields.Where(f => f.IsPrivate).ToArray() },
                { "protected", () => fields.Where(f => f.IsFamily).ToArray() },
                { "public", () => fields.Where(f => f.IsPublic).ToArray() },
                { "all", () => fields }
            };

            //FieldInfo[] filterFields;

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                #region switch () { }
                /*
                switch (input)
                {
                    case "protected":
                        filterFields = fields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "private":
                        filterFields = fields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "public":
                        filterFields = fields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "all":
                        filterFields = fields;
                        break;
                    default:
                        filterFields = null;
                        break;
                }

                string[] result = filterFields.Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}").ToArray();
                Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
                 */
                #endregion

                filter[input]()
                    .Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}")
                    .ToList()
                    .ForEach(f => Console.WriteLine(f.Replace("family", "protected")));
            }
        }
    }
}
