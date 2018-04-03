namespace Exercise_07_Inferno_Infinity.Core.Factories
{
    using Contracts;
    using Models;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory : IGemFactory
    {
        public IMagicalStats CreateGem(string[] data)
        {
            string gemType = data[0];

            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == gemType);

            if (type == null)
            {
                throw new ArgumentException(
                    "Invalid GemType!");
            }

            Clarity gemClarity;
            if (!Enum.TryParse<Clarity>(data[1], out gemClarity))
            {
                throw new ArgumentException(
                    "Invalid GemClarity!");
            }

            object[] parameters = new object[] { gemClarity };

            if (!typeof(IMagicalStats).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(
                    "GemType don't inherit IMagicalStats!");
            }

            IMagicalStats gem = (IMagicalStats)Activator.CreateInstance(type, parameters);

            return gem;
        }
    }
}
