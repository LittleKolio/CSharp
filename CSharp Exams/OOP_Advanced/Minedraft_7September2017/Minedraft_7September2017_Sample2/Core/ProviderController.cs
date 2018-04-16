using System;
using System.Collections.Generic;
using System.Linq;

public class ProviderController : IProviderController
{
    private List<IProvider> providers;
    private IEnergyRepository energyRepository;
    private IProviderFactory factory;

    public ProviderController(IEnergyRepository energyRepository, IProviderFactory factory)
    {
        this.energyRepository = energyRepository;
        this.factory = factory;
        this.providers = new List<IProvider>();
    }

    public double TotalEnergyProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.providers.AsReadOnly();

    public string Register(IList<string> args)
    {
        var provider = this.factory.GenerateProvider(args);
        this.providers.Add(provider);

        return string.Format(Constants.SuccessfullRegistration, 
            provider.GetType().Name);
    }

    public string Produce()
    {
        double energyProduced = this.providers.Select(n => n.Produce()).Sum();
        this.energyRepository.StoreEnergy(energyProduced);

        this.TotalEnergyProduced += energyProduced;

        List<IProvider> reminder = new List<IProvider>();

        foreach (IProvider provider in this.providers)
        {
            try
            {
                provider.Broke();
            }
            catch
            {
                reminder.Add(provider);
            }
        }

        foreach (IProvider entity in reminder)
        {
            this.providers.Remove(entity);
        }

        return string.Format(Constants.EnergyOutputToday, energyProduced);
    }

    public string Repair(int id, double value)
    {
        this.providers
            .FirstOrDefault(p => p.ID == id)
            .Repair(value);

        return string.Format(Constants.ProvidersRepaired, value);
    }
}