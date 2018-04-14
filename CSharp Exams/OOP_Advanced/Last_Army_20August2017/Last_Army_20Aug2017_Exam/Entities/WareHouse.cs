using System;
using System.Collections.Generic;

public class WareHouse : IWareHouse
{
    public WareHouse()
    {
        this.Ammunitions = new Dictionary<string, int>();
    }
    public IDictionary<string, int> Ammunitions { get; private set; }

    public void EquipArmy(IArmy army)
    {
        throw new NotImplementedException();
    }
}