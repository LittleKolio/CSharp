using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvesters;
    private IHarvesterFactory factory;
    private IEnergyRepository energyRepository;
    private Mode mode;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory factory)
    {
        this.energyRepository = energyRepository;
        this.factory = factory;
        this.harvesters = new List<IHarvester>();
        this.mode = Mode.Full;
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        bool isMode = Enum.TryParse(mode, true, out this.mode);

        if (!isMode)
        {
            throw new ArgumentException("Invalide ModeType!");
        }

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (IHarvester harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch
            {
                reminder.Add(harvester);
            }
        }

        foreach (IHarvester entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChange, this.mode);
    }

    public string Produce()
    {
        Func<double, double> modifier = 
            energyOrOre => energyOrOre * (int)this.mode / 100D;

        double energyNeeded = this.harvesters
            .Select(h => modifier(h.EnergyRequirement))
            .Sum();

        string result = string.Empty;
        double oreProducedToday = 0.0;

        if (this.energyRepository.TakeEnergy(energyNeeded))
        {
            oreProducedToday = this.harvesters
                .Select(h => modifier(h.Produce())).Sum();

            this.OreProduced += oreProducedToday;
        }

        return string.Format(Constants.OreOutputToday, oreProducedToday);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
}