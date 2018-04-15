using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;

[TestFixture]
public class TestMissionController
{

    //private class FakeSoldier : ISoldier
    //{
    //    #region Not needed
    //    public int Age { get; }

    //    public double Endurance { get; }

    //    public double Experience { get; }

    //    public string Name { get; }

    //    public IDictionary<string, IAmmunition> Weapons { get; }

    //    public void Regenerate()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void CompleteMission(IMission mission)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    #endregion

    //    public double OverallSkill => 50D;

    //    public bool ReadyForMission(IMission mission) => true;
    //}

    [Test]
    public void SuccessfulMission()
    {
        Mock<ISoldier> soldier1 = new Mock<ISoldier>();
        soldier1.Setup(s => s.ReadyForMission(It.IsAny<Mission>())).Returns(true);
        soldier1.Setup(s => s.OverallSkill).Returns(100);

        Mock<ISoldier> soldier2 = new Mock<ISoldier>();
        soldier1.Setup(s => s.ReadyForMission(It.IsAny<Mission>())).Returns(true);
        soldier1.Setup(s => s.OverallSkill).Returns(200);

        Mock<ISoldier> soldier3 = new Mock<ISoldier>();
        soldier1.Setup(s => s.ReadyForMission(It.IsAny<Mission>())).Returns(true);
        soldier1.Setup(s => s.OverallSkill).Returns(300);

        IArmy army = new Army();
        army.AddSoldier(soldier1.Object);
        army.AddSoldier(soldier2.Object);
        army.AddSoldier(soldier3.Object);

        IWareHouse wareHouse = new WareHouse(new AmmunitionFactory());

        Mock<IMission> mission = new Mock<IMission>();
        mission.Setup(m => m.ScoreToComplete).Returns(600);

        IMissionController controller = new MissionController(army, wareHouse);
        controller.PerformMission(mission.Object);

        Assert.That(controller.SuccessMissionCounter, Is.EqualTo(1));
    }
}