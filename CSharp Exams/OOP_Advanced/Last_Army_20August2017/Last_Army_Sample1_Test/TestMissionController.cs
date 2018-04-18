using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class TestMissionController
{
    //Too much work.
    private class FakeSoldier : ISoldier
    {
        #region Not needed
        public int Age { get; }

        public double Endurance { get; }

        public double Experience { get; }

        public string Name { get; }

        public IDictionary<string, IAmmunition> Weapons { get; }

        public void Regenerate() { throw new NotImplementedException(); }
        #endregion

        private bool readyForMission;

        public FakeSoldier(double overallSkill, bool readyForMission)
        {
            this.OverallSkill = overallSkill;
            this.readyForMission = readyForMission;
        }

        public double OverallSkill { get; }

        public bool ReadyForMission(IMission mission) => this.readyForMission;

        public void CompleteMission(IMission mission) { }
    }
    private class FakeWareHouse : IWareHouse
    {
        #region Not needed
        public void AddAmmunition(string ammunition, int amount) { throw new NotImplementedException(); }

        public bool GetAmmonition(string ammunition) { throw new NotImplementedException(); }

        public bool TryEquipSoldier(ISoldier soldier) { throw new NotImplementedException(); }
        #endregion

        public void EquipArmy(IList<ISoldier> army) { }
    }

    //Field
    private IArmy fakeArmy;
    private IWareHouse fakeWareHouse;
    private IMissionController fakeController;

    [SetUp]
    public void SetUp()
    {
        this.fakeArmy = new Army();
        this.fakeWareHouse = new FakeWareHouse();
        this.fakeController = new MissionController(fakeArmy, fakeWareHouse);
    }


    //[Test]
    //public void SuccessfulMission_Mock()
    //{
    //    IDictionary<string, IAmmunition> Weaps =
    //        new Dictionary<string, IAmmunition>()
    //    {
    //        { "Gun", new Gun() },
    //        { "AutomaticMachine", new AutomaticMachine() },
    //        { "Helmet", new Helmet() }
    //    };

    //    Mock<ISoldier> soldier1 = new Mock<ISoldier>();
    //    soldier1.Setup(s => s.ReadyForMission(It.IsAny<Mission>())).Returns(true);
    //    soldier1.Setup(s => s.OverallSkill).Returns(100);
    //    soldier1.Setup(s => s.Weapons).Returns(Weaps);

    //    IArmy army = new Army();
    //    army.AddSoldier(soldier1.Object);

    //    IWareHouse wareHouse = new WareHouse(new AmmunitionFactory());

    //    Mock<IMission> mission = new Mock<IMission>();
    //    mission.Setup(m => m.ScoreToComplete).Returns(600);

    //    IMissionController controller = new MissionController(army, wareHouse);

    //    controller.PerformMission(mission.Object);

    //    Assert.That(controller.SuccessMissionCounter, Is.EqualTo(1));
    //}

    [Test]
    public void SuccessfulMissions()
    {
        //Arrange
        IList<ISoldier> soldiers = new List<ISoldier>()
        {
            new FakeSoldier (100, true),
            new FakeSoldier (200, true),
            new FakeSoldier (300, true)
        };

        foreach (ISoldier soldier in soldiers)
            fakeArmy.AddSoldier(soldier);

        IMission hardMission = new Hard(600);
        IMission mediumMission = new Medium(500);
        IMission easyMission = new Easy(200);

        IMission diehardMission = new Hard(601);


        //Act
        fakeController.PerformMission(hardMission);
        fakeController.PerformMission(mediumMission);
        fakeController.PerformMission(easyMission);

        //Assert
        Assert.That(fakeController.SuccessMissionCounter, Is.EqualTo(3));
    }

    [Test]
    public void FailedMissions_FailMissionsOnHold()
    {
        //Arrange
        //OverallSkill sum = 400
        IList<ISoldier> soldiers = new List<ISoldier>()
        {
            new FakeSoldier (100, true),
            new FakeSoldier (200, false),
            new FakeSoldier (300, true)
        };

        foreach (ISoldier soldier in soldiers)
            fakeArmy.AddSoldier(soldier);

        IMission hardMission = new Hard(399);
        IMission mediumMission = new Medium(401);
        IMission easyMission = new Easy(double.MaxValue);

        //Act
        fakeController.PerformMission(hardMission);
        fakeController.PerformMission(mediumMission);
        fakeController.PerformMission(easyMission);
        fakeController.FailMissionsOnHold();

        //Assert
        Assert.That(fakeController.SuccessMissionCounter, Is.EqualTo(1));
        Assert.That(fakeController.FailedMissionCounter, Is.EqualTo(2));
        Assert.That(fakeController.Missions.Count, Is.EqualTo(0));
    }

    [Test]
    public void FailedMissions()
    {
        //Arrange
        //OverallSkill sum = 400
        IList<ISoldier> soldiers = new List<ISoldier>()
        {
            new FakeSoldier (100, true),
            new FakeSoldier (200, false),
            new FakeSoldier (300, true)
        };

        foreach (ISoldier soldier in soldiers)
            fakeArmy.AddSoldier(soldier);

        IMission hardMission = new Hard(399);
        IMission mediumMission = new Medium(401);
        IMission easyMission = new Easy(double.MaxValue);

        //Act
        fakeController.PerformMission(hardMission);
        fakeController.PerformMission(mediumMission);
        fakeController.PerformMission(easyMission);

        //Assert
        Assert.That(fakeController.SuccessMissionCounter, Is.EqualTo(1));
        Assert.That(fakeController.FailedMissionCounter, Is.EqualTo(0));
        Assert.That(fakeController.Missions.Count, Is.EqualTo(2));
    }
}