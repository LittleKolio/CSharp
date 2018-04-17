using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class TestProviderController
{

    private IProviderController controller;
    private IEnergyRepository energy;
    private IProviderFactory factory;

    [SetUp]
    public void Initialize()
    {
        factory = new ProviderFactory();
        energy = new EnergyRepository();
        controller = new ProviderController(energy, factory);
    }

    [TestCase("Standart 20 60")]
    public void Register_StandartProvider_ValidInput(string input)
    {
        //Arrange
        List<string> testArgs = input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        //Assert
        Assert.That(controller.Register(testArgs), 
            Is.EqualTo("Successfully registered StandartProvider"));

        Assert.That(controller.Entities.Count(), Is.EqualTo(1));
    }

    [TestCase("Solar 80 80")]
    public void Register_SolarProvider_ValidInput(string input)
    {
        //Arrange
        List<string> testArgs = input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        //Assert
        Assert.That(controller.Register(testArgs),
            Is.EqualTo("Successfully registered SolarProvider"));

        Assert.That(controller.Entities.Count(), Is.EqualTo(1));
    }

    [TestCase("Pressure 40 100")]
    public void Register_PressureProvider_ValidInput(string input)
    {
        //Arrange
        List<string> testArgs = input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        //Assert
        Assert.That(controller.Register(testArgs),
            Is.EqualTo("Successfully registered PressureProvider"));

        Assert.That(controller.Entities.Count(), Is.EqualTo(1));
    }

    [Test]
    public void Produce_EnergyProducedToday()
    {
        //Arrange
        List<List<string>> list = new List<List<string>>()
        {
            new List<string>() { "Pressure", "40", "100" },
            new List<string>() { "Solar", "80", "80" },
            new List<string>() { "Standart", "20", "60" }
        };

        foreach (IList<string> args in list)
        {
            controller.Register(args);
        }

        //Assert
        Assert.That(controller.Produce(),
            Is.EqualTo("Produced 340 energy today!"));
    }

    [Test]
    public void Produce_TotalEnergyProduced()
    {
        //Arrange
        List<List<string>> list = new List<List<string>>()
        {
            new List<string>() { "Pressure", "40", "100" },
            new List<string>() { "Solar", "80", "80" },
            new List<string>() { "Standart", "20", "60" }
        };

        foreach (IList<string> args in list)
        {
            controller.Register(args);
        }

        //Act
        controller.Produce();
        controller.Produce();

        //Assert
        Assert.That(controller.TotalEnergyProduced, Is.EqualTo(680));
    }
}