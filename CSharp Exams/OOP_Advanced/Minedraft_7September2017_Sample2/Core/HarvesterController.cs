using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private List<IHarvester> harvesters;
    private IHarvesterFactory factory;
    private IEnergyRepository energyRepository;
    private Mode mode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.harvesters = new List<IHarvester>();
        this.factory = new HarvesterFactory();
        this.energyRepository = energyRepository;
        this.mode = Mode.Full;
    }

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        throw new NotImplementedException();
    }

    public string Produce()
    {
        Func<double, double> energyReqByMode = energyReq => energyReq * (int)this.mode / 100D;

        double energyNeeded = this.harvesters
            .Select(h => energyReqByMode(h.EnergyRequirement))
            .Sum();

        string result = string.Empty;
        double oreProducedToday = 0.0;

        if (this.energyRepository.TakeEnergy(energyNeeded))
        {
            oreProducedToday = this.harvesters.Select(h => h.Produce()).Sum();
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