using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MissionController
{
    private Queue<IMission> missionQueue;
    private Army army;
    private WareHouse wareHouse;

    public MissionController(Army army, WareHouse wareHouse)
    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.missionQueue = new Queue<IMission>();
    }

    public int SuccessMissionCounter { get; private set; }

    public int FailedMissionCounter { get; private set; }

    public Queue<IMission> Missions => this.missionQueue;

    public string PerformMission(IMission mission)
    {
        StringBuilder sb = new StringBuilder();

        IMission oldesMission = this.missionQueue.Dequeue();

        if (this.missionQueue.Count >= 3)
        {
            sb.AppendLine(string.Format(Message.MissionDeclined, oldesMission.Name));
            this.FailedMissionCounter++;
        }

        this.missionQueue.Enqueue(mission);

        for (int i = 0; i < this.missionQueue.Count; i++)
        {
            IList<ISoldier> army = this.army.Soldiers.ToList();

            this.wareHouse.EquipArmy(army);

            IMission currentMission = this.missionQueue.Dequeue();

            IList<ISoldier> missionTeam = army.Where(s => s.ReadyForMission(mission)).ToList();

            bool successful = this.ExecuteMission(currentMission, missionTeam);

            if (successful)
            {
                this.SuccessMissionCounter++;
                sb.AppendLine(string.Format(Message.MissionSuccessful, currentMission.Name));
            }
            else
            {
                this.missionQueue.Enqueue(currentMission);
                sb.AppendLine(string.Format(Message.MissionOnHold, currentMission.Name));
            }
        }

        return sb.ToString();
    }

    public bool ExecuteMission(IMission mission, IList<ISoldier> missionTeam)
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

    public void FailMissionsOnHold()
    {
        while (this.missionQueue.Count > 0)
        {
            this.FailedMissionCounter++;
            this.missionQueue.Dequeue();
        }
    }
}