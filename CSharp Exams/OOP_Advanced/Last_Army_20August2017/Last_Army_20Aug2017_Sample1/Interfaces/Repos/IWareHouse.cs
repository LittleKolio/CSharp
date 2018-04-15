using System.Collections.Generic;

public interface IWareHouse
{
    void AddAmmunition(string ammunition, int amount);

    bool GetAmmonition(string ammunition);

    bool TryEquipSoldier(ISoldier soldier);

    void EquipArmy(IList<ISoldier> army);
}