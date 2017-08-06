namespace Unit_Testing_Lab.Test
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class HeroTest
    {
        [Test]
        public void GetExperience()
        {
            //Arrange
            Hero hero = new Hero("Tatu", new Axe(10, 10));
            Dummy dummy = new Dummy(20, 20);

            //Act
            hero.Attack(dummy);
            hero.Attack(dummy);

            //Assert
            Assert.AreEqual(20, hero.Experience, "Hero's experience doesn't change");
        }

        [Test]
        public void MockingTest()
        {
            Mock<IWeapon> weapon = new Mock<IWeapon>();

            weapon
                .Setup(w => w.Attack(It.IsAny<ITarget>()))
                .Callback(() => weapon.Object.DurabilityPoints -= 1);

            Hero hero = new Hero("Tatu", weapon.Object);
        }
    }
}
