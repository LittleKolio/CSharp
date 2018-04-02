namespace Exercise_03_BarracksWars_A_New_Factory.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
