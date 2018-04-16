public interface IProviderController : IController
{
    double TotalEnergyProduced { get; }

    string Repair(int id, double val);
}