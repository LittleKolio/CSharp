namespace Unit_Testing_Lab.Test
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTest
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const int DummyHealth = 20;
        private const int DummyExperience = 20;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            //Arange
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeLosesDurability()
        {
            //Arange
            //Axe axe = new Axe(attack, durability);
            //Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            //Assert.AreEqual(9, axe.DurabilityPoints);
            Assert.IsTrue(axe.DurabilityPoints == 9);
        }

        [Test]
        public void BrokenAxe()
        {
            //Arange
            //Axe axe = new Axe(1, 1);
            //Dummy dummy = new Dummy(10, 10);
            this.axe = new Axe(1, 1);


            //Act
            axe.Attack(dummy);

            //Assert

            //Assert.Throws<InvalidOperationException>(
            //    () => axe.Attack(dummy)
            //    );

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy)
                );

            Assert.AreEqual("Axe is broken.", ex.Message);
        }
    }
}
