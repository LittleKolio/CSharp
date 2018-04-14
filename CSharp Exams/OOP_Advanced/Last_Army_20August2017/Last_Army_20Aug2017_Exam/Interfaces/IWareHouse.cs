using System.Collections.Generic;

public interface IWareHouse
{
    IDictionary<string, int> Ammunitions { get; }

    void EquipArmy(IArmy army);
}