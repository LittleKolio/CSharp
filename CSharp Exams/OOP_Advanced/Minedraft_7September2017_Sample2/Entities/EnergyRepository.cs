using System;

public class EnergyRepository : IEnergyRepository
{
    private double energyStored;

    public EnergyRepository()
    {
        this.energyStored = 0.0;
    }

    public double EnergyStored => this.energyStored;

    public void StoreEnergy(double energy)
    {
        this.energyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if (this.EnergyStored < energyNeeded)
        {
            return false;
        }

        this.energyStored -= energyNeeded;

        return true;
    }
}