using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GameController
{
    private MissionController missionController;
    private SoldiersFactory soldiersFactory;
    private MissionFactory missionFactory;
    private Army army;
    private WareHouse wareHouse;

    public GameController(
        MissionController missionController,
        SoldiersFactory soldiersFactory,
        MissionFactory missionFactory,
        Army army, 
        WareHouse wareHouse)
    {
        this.missionController = missionController;
        this.soldiersFactory = soldiersFactory;
        this.missionFactory = missionFactory;
        this.wareHouse = wareHouse;
        this.army = army;
    }

    public void GiveInputToGameController(string[] data)
    {
        string methodName = data[0] + "Command";

        MethodInfo method = this.GetType()
            .GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

        if (method == null)
        {
            throw new ArgumentException(
                "Invalide Command!");
        }

        object[] parameters = new object[] { data.Skip(1).ToArray() };

        method.Invoke(this, parameters);
    }

    private void MissionCommand(string[] data)
    {
        string level = data[0];
        double points = double.Parse(data[1]);

        IMission mission = this.missionFactory.CreateMission(level, points);

        this.missionController.PerformMission(mission);
    }

    private void WareHouseCommand(string[] data)
    {
        string ammunitionName = data[0];
        int amount = int.Parse(data[1]);

        this.wareHouse.AddAmmunition(ammunitionName, amount);
    }

    private void SoldierCommand(string[] data)
    {
        string type = data[0];

        if (type == "Regenerate")
        {
            this.army.RegenerateTeam(data[1]);
        }
        else
        {
            string name = data[1];
            int age = int.Parse(data[2]);
            double experience = int.Parse(data[3]);
            double endurance = double.Parse(data[4]);

            ISoldier soldier = this.soldiersFactory.CreateSoldier(
                type, name, age, experience, endurance);

            bool equipped = this.wareHouse.TryEquipSoldier(soldier);

            if (!equipped)
            {
                throw new ArgumentException(
                    string.Format(Message.SoldierNotAddedToTheArmy, type, name));
            }

            this.army.AddSoldier(soldier);
        }
    }

    //public string RequestResult()
    //{
    //    return Output.GiveOutput(result, army, wearHouse, this.MissionController.MissionQueue.Count);
    //}

    //private void AddSoldierToArmy(ISoldier soldier, string type)
    //{
    //    if (!soldier.CheckIfSoldierCanJoinTeam())
    //    {
    //        throw new ArgumentException($"The soldier {soldier.Name} is not skillful enough {type} team");
    //    }

    //    if (!this.Army.ContainsKey(type))
    //    {
    //        this.Army[type] = new List<Soldier>();
    //    }
    //    this.Army[type].Add(soldier);
    //}
}