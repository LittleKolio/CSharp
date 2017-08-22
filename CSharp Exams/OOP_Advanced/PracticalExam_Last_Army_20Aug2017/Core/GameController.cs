using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GameController
{
    private SoldiersFactory soldierFactory;
    private WareHouse wareHouse;

    private Dictionary<string, List<ISoldier>> army;

    //private MissionController missionControllerField;

    public GameController()
    {
        this.soldierFactory = new SoldiersFactory();

        this.army = new Dictionary<string, List<ISoldier>>();
        //this.MissionControllerField = new MissionController();
    }

    public void CreateSoldierGameController(IList<string> data)
    {
        ISoldier soldier = this.soldierFactory.CreateSoldier(data);

        if (!this.army.ContainsKey(soldier.GetType().Name))
        {
            this.army.Add(
                soldier.GetType().Name,
                new List<ISoldier>()
                );
        }

        this.army[soldier.GetType().Name].Add(soldier);
    }

    public void GiveInputToGameController(string input)
    {
        IList<string> data = input.Split(
            new char[] { ' ' }, 
            StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string command = data[0];
        data.Remove(command);

        switch (command)
        {
            case "Soldier": this.CreateSoldierGameController(data); break;

            case "WareHouse":
                {

                } break;

            default:
                break;

        }

        //else if (data[0].Equals("WearHouse"))
        //{
        //    string name = data[1];
        //    int number = int.Parse(data[2]);

        //    AddAmmunitions(AmmunitionFactory.CreateAmmunitions(name, number));
        //}
        //else if (data[0].Equals("Mission"))
        //{
        //    this.MissionControllerField.PerformMission(new Easy());
        //}
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