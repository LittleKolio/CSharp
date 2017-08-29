using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GameController : IGameController
{
    private SoldiersFactory soldierFactory;
    private WareHouse wareHouse;

    private Dictionary<string, ISoldier> army;
    //private MissionController missionControllerField;

    public GameController()
    {
        this.soldierFactory = new SoldiersFactory();
        this.army = new Dictionary<string, ISoldier>();
        //this.MissionControllerField = new MissionController();
    }



    public string WareHouse(string name, int count)
    {
        return string.Empty;
    }

    public string Soldier(string type, string name, int age, double experience, double endurance)
    {
        ISoldier soldier = this.soldierFactory
            .CreateSoldier(type, name, age, experience, endurance);

        if (!this.army.ContainsKey(soldier.Name))
        {
            this.army.Add(soldier.Name, soldier);
        }

        return string.Empty;
    }

    public string Mission(string type)
    {
        return string.Empty;
    }

    private bool AmmunitionsForSoldier()
    {

    }

    //public string RequestResult()
    //{
    //    return Output.GiveOutput(result, army, wearHouse, this.MissionControllerField.MissionQueue.Count);
    //}

    //private void AddAmmunitions(Ammunition ammunition)
    //{
    //    if (!this.WearHouse.ContainsKey(ammunition.Name))
    //    {
    //        this.WearHouse[ammunition.Name] = new List<Ammunition>();
    //        this.WearHouse[ammunition.Name].Add(ammunition);
    //    }
    //    else
    //    {
    //        this.WearHouse[ammunition.Name][0].Number += ammunition.Number;
    //    }
    //}

    //private void AddSoldierToArmy(Soldier soldier, string type)
    //{
    //    if (!soldier.CheckIfSoldierCanJoinTeam())
    //    {
    //        throw new ArgumentException($"The soldier {soldier.Name} is not skillful enough {type} team");
    //    }

    //    if (!this.army.ContainsKey(type))
    //    {
    //        this.army[type] = new List<ISoldier>();
    //    }
    //    this.army[type].Add(soldier);
    //}
}