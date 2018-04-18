using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GameController : IGameController
{
    private IMissionController missionController;
    private ISoldierFactory soldiersFactory;
    private IMissionFactory missionFactory;
    private IArmy army;
    private IWareHouse wareHouse;
    private IWriter writer;

    public GameController(
        IMissionController missionController,
        ISoldierFactory soldiersFactory,
        IMissionFactory missionFactory,
        IArmy army, 
        IWareHouse wareHouse,
        IWriter writer)
    {
        this.missionController = missionController;
        this.soldiersFactory = soldiersFactory;
        this.missionFactory = missionFactory;
        this.wareHouse = wareHouse;
        this.army = army;
        this.writer = writer;
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

        try
        {
            method.Invoke(this, parameters);
        }
        catch (TargetInvocationException tie)
        {
            throw tie.InnerException;
        }
    }

    private void MissionCommand(string[] data)
    {
        string level = data[0];
        double points = double.Parse(data[1]);

        IMission mission = this.missionFactory.CreateMission(level, points);

        string result = this.missionController.PerformMission(mission);

        this.writer.WriteLine(result);
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
                    string.Format(OutputMessages.SoldierNotAddedToTheArmy, type, name));
            }

            this.army.AddSoldier(soldier);
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();

        this.writer.WriteLine(this.missionController.ToString());
        this.writer.WriteLine(this.army.ToString());
    }
}