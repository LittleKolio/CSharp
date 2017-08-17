namespace RecyclingStation.Factory
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;
    using WasteDisposal.Interfaces;

    public class WasteFactory : IWasteFactory
    {
        public IWaste GetWaste(string name, double weight, double volumePerKg, string type)
        {
            Type wasteType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(
                    t => t.Name.Equals(type, 
                        StringComparison.OrdinalIgnoreCase)
                );
            IWaste waste = (IWaste)Activator.CreateInstance(
                wasteType,
                new object[] { name, weight, volumePerKg }
                );

            return waste;
        }
    }
}
