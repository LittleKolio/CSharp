namespace Exercise_02_Kings_Gambit
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class SubordinateFactory
    {
        public ISubordinate CreateSub(string type, string name)
        {
            Type SubType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            if (type == null)
            {
                throw new ArgumentException(
                    "Invalid SubordinateType!");
            }

            object[] parameters = new object[] { name };

            if (!typeof(ISubordinate).IsAssignableFrom(SubType))
            {
                throw new InvalidOperationException(
                    "SubordinateType don't inherit ISubordinate!");
            }

            ISubordinate sub = (ISubordinate)Activator.CreateInstance(SubType, parameters);

            return sub;
        }
    }
}
