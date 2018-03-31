namespace Exercise_01_Harvesting_Fields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private FieldInfo[] fields;

        public Engine()
        {
            //this.type = Assembly
            //    .GetExecutingAssembly()
            //    .GetType("Exercise_01_Harvesting_Fields.HarvestingFields");

            this.fields = typeof(HarvestingFields)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }

        public void Run()
        {
            string cmd;
            while (!(cmd = Console.ReadLine()).Equals("HARVEST"))
            {
                FieldInfo[] fields = null;

                try
                {
                    fields = this.CommadSwitcher(cmd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                this.Print(fields);
            }
        }

        private void Print(FieldInfo[] fields)
        {
            foreach (FieldInfo field in fields)
            {
                string access = string.Empty;
                switch (field.Attributes)
                {
                    case FieldAttributes.Private:
                        access = "private";
                        break;

                    case FieldAttributes.Family:
                        access = "protected";
                        break;

                    case FieldAttributes.Public:
                        access = "public";
                        break;
                }
                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
            }
        }

        private FieldInfo[] CommadSwitcher(string cmd)
        {
            switch (cmd)
            {
                case "private": return this.fields.Where(f => f.IsPrivate).ToArray();

                case "protected": return this.fields.Where(f => f.IsFamily).ToArray();

                case "public": return this.fields.Where(f => f.IsPublic).ToArray();

                case "all": return this.fields;

                default: throw new ArgumentException("Invalide command!");
            }
        }
    }
}
