namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Type setType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            //if (setType == null)
            //{
            //    throw new ArgumentException();
            //}

            //if (!typeof(ISet).IsAssignableFrom(setType))
            //{
            //    throw new InvalidOperationException();
            //}

            ISet set = (ISet)Activator.CreateInstance(setType, name);

            return set;
        }
	}
}
