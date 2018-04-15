using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MissionController : IMissionController
{
    private Queue<IMission> missionQueue;
    private IArmy army;
    private IWareHouse wareHouse;


    public MissionController(IArmy army, IWareHouse wareHouse)
    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.missionQueue = new Queue<IMission>();
        this.SuccessMissionCounter = 0;
        this.FailedMissionCounter = 0;
    }

    public int SuccessMissionCounter { get; private set; }

    public int FailedMissionCounter { get; private set; }

    public Queue<IMission> Missions => this.missionQueue;

    public string PerformMission(IMission mission)
    {
        StringBuilder sb = new StringBuilder();

        if (this.missionQueue.Count >= 3)
        {
            IMission oldesMission = this.missionQueue.Dequeue();
            sb.AppendLine(string.Format(Message.MissionDeclined, oldesMission.Name));
            this.FailedMissionCounter++;
        }

        this.missionQueue.Enqueue(mission);

        for (int i = 0; i < this.missionQueue.Count; i++)
        {
            IList<ISoldier> soldiers = this.army.Soldiers.ToList();

            this.wareHouse.EquipArmy(soldiers);

            IMission currentMission = this.missionQueue.Dequeue();

            IList<ISoldier> missionTeam = soldiers.Where(s => s.ReadyForMission(currentMission)).ToList();

            bool successful = this.ExecuteMission(currentMission, missionTeam);

            if (successful)
            {
                sb.AppendLine(string.Format(Message.MissionSuccessful, currentMission.Name));
            }
            else
            {
                this.missionQueue.Enqueue(currentMission);
                sb.AppendLine(string.Format(Message.MissionOnHold, currentMission.Name));
            }
        }

        return sb.ToString().TrimEnd();
    }

    private bool ExecuteMission(IMission mission, IList<ISoldier> missionTeam)
    {
        double teamOverallSkill = missionTeam
            .Select(s => s.OverallSkill)
            .Sum();

        if (teamOverallSkill >= mission.ScoreToComplete)
        {
            foreach (ISoldier soldier in missionTeam)
            {
                soldier.CompleteMission(mission);
            }
            this.SuccessMissionCounter++;
            return true;
        }

        return false;
    }

    public void CalcFailMissions()
    {
        while (this.missionQueue.Count > 0)
        {
            this.FailedMissionCounter++;
            this.missionQueue.Dequeue();
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("Results:" + Environment.NewLine);
        sb.AppendLine($"Successful missions - {this.SuccessMissionCounter}")
            .AppendLine($"Failed missions - {this.FailedMissionCounter}");

        return sb.ToString().TrimEnd();
    }
}