namespace Minedraft_7September2017.Test
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class TestProviderController
    {
        private class FakeEnergyRepository : IEnergyRepository
        {
            private double customField = 1200.12;

            //It can return anything what we need
            public double EnergyStored
            {
                get { return this.customField; }
            }

            public void StoreEnergy(double energy)
            {
                throw new NotImplementedException();
            }

            public bool TakeEnergy(double energyNeeded)
            {
                throw new NotImplementedException();
            }
        }

        private IProviderController testProviderController;

        [SetUp]
        public void Initialize()
        {
            IProviderFactory providerFactory = new ProviderFactory();
            //IEnergyRepository energyRepository = new EnergyRepository();
            IEnergyRepository energyRepository = new FakeEnergyRepository();
            testProviderController = new ProviderController(energyRepository, providerFactory);
        }

        //public IProviderController ProviderControllerFactory()
        //{
        //    IProviderFactory providerFactory = new ProviderFactory();
        //    IEnergyRepository energyRepository = new EnergyRepository();
        //    return new ProviderController(energyRepository, providerFactory);
        //}

        [TestCase("Pressure 40 100")]
        public void RegisterProvider_ValidInput(string input)
        {
            //Arrange

            Mock<IEnergyRepository> energyRepositoryMoq = new Mock<IEnergyRepository>();
            energyRepositoryMoq.Setup(e => e.EnergyStored).Returns(1200.12);

            //IProviderController testProviderController = ProviderControllerFactory();

            List<string> testArgs = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            //Act

            //Assert
            Assert.That(testProviderController.Register(testArgs), 
                Is.EqualTo("Successfully registered PressureProvider"));

            Assert.That(testProviderController.Entities.Count(), Is.EqualTo(1));
        }
    }
}
