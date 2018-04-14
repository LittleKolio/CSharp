using System;
using System.Collections.Generic;
using System.Text;

public class GameController
{
    private MissionController missionController;
    private AmmunitionFactory ammunitionFactory;
    private WearHouse wearHouse;
    private Army army;

    public GameController(
        MissionController missionController,
        AmmunitionFactory ammunitionFactory,
        Army army, 
        WearHouse wearHouse)
    {
        this.missionController = missionController;
        this.wearHouse = wearHouse;
        this.army = army;
    }

    public void GiveInputToGameController(string[] data)
    {
        switch (data[0])
        {
            case "Soldier":
                {
                    string type = data[1];
                    string name = data[2];
                    int age = int.Parse(data[3]);
                    double experience = int.Parse(data[4]);
                    double endurance = double.Parse(data[5]);

                    ISoldier soldier = this.soldiersFactory.CreateSoldier(
                        type, name, age, experience, endurance);

                    this.AddSoldierToArmy(soldier);
                }
                break;

            case "WareHouse":
                {
                    string ammunitionName = data[1];
                    int amount = int.Parse(data[2]);

                    this.wearHouse.AddAmmunition(ammunitionName, amount);
                }
                break;

            case "Mission":
                {

                }
                break;

            default:
                break;
        }
    }

    public string RequestResult()
    {
        //return Output.GiveOutput(result, army, wearHouse, this.MissionController.MissionQueue.Count);
    }

    private void AddAmmunitions(Ammunition ammunition)
    {
        //if (!this.WearHouse.ContainsKey(ammunition.Name))
        //{
        //    this.WearHouse[ammunition.Name] = new List<Ammunition>();
        //    this.WearHouse[ammunition.Name].Add(ammunition);
        //}
        //else
        //{
        //    this.WearHouse[ammunition.Name][0].Number += ammunition.Number;
        //}
    }

    private void AddSoldierToArmy(ISoldier soldier, string type)
    {
        if (!soldier.CheckIfSoldierCanJoinTeam())
        {
            throw new ArgumentException($"The soldier {soldier.Name} is not skillful enough {type} team");
        }

        if (!this.Army.ContainsKey(type))
        {
            this.Army[type] = new List<Soldier>();
        }
        this.Army[type].Add(soldier);
    }
}