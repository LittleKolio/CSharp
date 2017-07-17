using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;

    private List<Day> days;

    private HarvesterFactory factoryHarvester;
    private ProviderFactory factoryProvider;

    private string mode;
    private double energyStored;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.factoryHarvester = new HarvesterFactory();
        this.factoryProvider = new ProviderFactory();
        this.days = new List<Day>();
        this.mode = "Full";
        this.energyStored = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = this.factoryHarvester.GetHarvester(arguments);

            if (this.mode == "Half")
            {
                harvester.HalfMode();
            }
            if (this.mode == "Energy")
            {
                harvester.EnergyMode();
            }

            this.harvesters.Add(harvester);

            return string.Format(
                Constants.SUCCESS_REGISTER_HARVESTER,
                harvester.GetType().Name.Replace("Harvester", string.Empty),
                harvester.Id
                );
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }

    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = this.factoryProvider.GetProvider(arguments);
            providers.Add(provider);
            return string.Format(
                Constants.SUCCESS_REGISTER_PROVIDER,
                provider.GetType().Name.Replace("Provider", string.Empty),
                provider.Id
                );
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }
    public string Day()
    {
        this.energyStored = this.energyStored + providers.Sum(p => p.EnergyOutput);
        double energyRequirement = harvesters.Sum(h => h.EnergyRequirement);
        double minedOre = this.harvesters.Sum(h => h.OreOutput);

        if (this.energyStored >= energyRequirement)
        {
            this.energyStored = this.energyStored - energyRequirement;
            this.days.Add(new Day(
                this.energyStored,
                minedOre
                ));
        }
        else
        {
            this.days.Add(new Day(
                this.energyStored,
                0.0
                ));
        }

        return days[days.Count - 1].ToString();
    }
    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        return string.Format(
            Constants.SUCCESS_CHANGE_MODE,
            this.mode
            );
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Harvester harvester = this.harvesters
            .Where(h => h.Id == id)
            .FirstOrDefault();
        if (harvester != null)
        {
            return harvester.ToString();
        }

        Provider provider = this.providers
            .Where(p => p.Id == id)
            .FirstOrDefault();
        if (provider != null)
        {
            return provider.ToString();
        }

        return string.Format(
            Constants.EXEPTION_CHECK,
            id
            );
    }
    public string ShutDown()
    {
        double minedOre = this.days.Sum(d => d.MinedOre);
        return string.Format(
            Constants.TOSTRING_SHUTHDOWN,
            this.energyStored,
            minedOre
            );
    }
}
