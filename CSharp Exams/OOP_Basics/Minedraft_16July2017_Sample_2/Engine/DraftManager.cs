using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private double totalStoredEnergy;
    private double totalMinedOre;
    private string mode;
    private double enReqModifier;
    private double oreOutModifier;

    private List<Harvester> harvesters;
    private List<Provider> providers;

    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.mode = "Full";
        SetModifiers();
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public double EnergyRequirement => this.harvesters.Sum(h => h.EnergyRequirement) * this.enReqModifier;
    public double OreOutput => this.harvesters.Sum(h => h.OreOutput) * this.oreOutModifier;
    public double EnergyOutput => this.providers.Sum(h => h.EnergyOutput);

    private void SetModifiers()
    {
        switch (this.mode)
        {
            case "Full":
                {
                    this.enReqModifier = 1;
                    this.oreOutModifier = 1;
                } break;
            case "Half":
                {
                    this.enReqModifier = 0.6;
                    this.oreOutModifier = 0.5;
                }
                break;
            case "Energy":
                {
                    this.enReqModifier = 0;
                    this.oreOutModifier = 0;
                }
                break;
            default:
                break;
        }
    }

    //FORMAT: {type} {id} {oreOutput} {energyRequirement}
    //FORMAT:  Sonic {id} {oreOutput} {energyRequirement} {sonicFactor}
    public string RegisterHarvester(List<string> arguments)
    {
        Harvester harvester = default(Harvester);
        try
        {
            harvester = this.harvesterFactory.GetHarvester(arguments);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        this.harvesters.Add(harvester);

        return string.Format("Successfully registered {0} Harvester - {1}",
            arguments[0], harvester.Id);
    }

    //FORMAT: {type} {id} {energyOutput}
    public string RegisterProvider(List<string> arguments)
    {
        Provider provider = default(Provider);
        try
        {
            provider = this.providerFactory.GetProvider(arguments);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        this.providers.Add(provider);

        return string.Format("Successfully registered {0} Provider - {1}",
            arguments[0], provider.Id);
    }


    //CALCULATE: all the provided energy and STORE it in the system
    //CHECK: if there is enough energy for harvesters to start mining
    //NOTE: The summed up energyRequirement might be less or more depending on the current working Mode.
    public string Day()
    {
        this.totalStoredEnergy += this.EnergyOutput;
        double oreByMode = 0;
        if (this.totalStoredEnergy >= this.EnergyRequirement)
        {
            this.totalStoredEnergy -= this.EnergyRequirement;
            this.totalMinedOre += this.OreOutput;
            oreByMode = this.OreOutput;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendFormat("Energy Provided: {0}" + Environment.NewLine, this.EnergyOutput)
            .AppendFormat("Plumbus Ore Mined: {0}" + Environment.NewLine, oreByMode);

        return sb.ToString().TrimEnd();
    }
    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        SetModifiers();
        return string.Format(
            "Successfully changed working mode to {0} Mode", this.mode);
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Provider provider = this.providers.Find(p => p.Id == id);
        if (provider != null)
        {
            return provider.ToString();
        }

        Harvester harvester = this.harvesters.Find(h => h.Id == id);
        if (harvester != null)
        {
            return harvester.ToString();
        }

        return string.Format("No element found with id - {0}", id);
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendFormat("Total Energy Stored: {0}" + Environment.NewLine, this.totalStoredEnergy)
            .AppendFormat("Total Mined Plumbus Ore: {0}" + Environment.NewLine, this.totalMinedOre);

        return sb.ToString().TrimEnd();
    }
}