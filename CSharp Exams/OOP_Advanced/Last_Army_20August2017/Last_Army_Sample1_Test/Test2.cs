using System;
using NUnit.Framework;

[TestFixture]
public class Test2
{
    private IArmy army;
    private IAmmunitionFactory factory;
    private IWareHouse wareHouse;
    private IMissionController controller;

    [SetUp]
    public void Initialization()
    {
        this.army = new Army();
        this.factory = new AmmunitionFactory();
        this.wareHouse = new WareHouse(this.factory);
        this.controller = new MissionController(this.army, this.wareHouse);
    }

    [Test]
    public void PerformMission_EasyMission()
    {
        IMission mission = new Easy(10);

        Assert.That(controller.PerformMission(mission), 
            Is.EqualTo("Mission on hold - Suppression of civil rebellion"));
    }

    [Test]
    public void PerformMission_MediumMission()
    {
        IMission mission = new Medium(10);

        Assert.That(controller.PerformMission(mission),
            Is.EqualTo("Mission on hold - Capturing dangerous criminals"));
    }

    [Test]
    public void PerformMission_HardMission()
    {
        IMission mission = new Hard(10);

        Assert.That(controller.PerformMission(mission),
            Is.EqualTo("Mission on hold - Disposal of terrorists"));
    }
}
