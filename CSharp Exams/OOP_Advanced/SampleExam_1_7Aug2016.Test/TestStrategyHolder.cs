namespace SampleExam_1_7Aug2016.Test
{
    using System;
    using NUnit.Framework;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.Models.GarbageStrategy;
    using RecyclingStation.WasteDisposal.Attributes;
    using System.Collections.Generic;
    using System.Linq;
    using RecyclingStation.Models.Attributes;

    [TestFixture]
    public class TestStrategyHolder
    {
        private IGarbageDisposalStrategy disposalStrategy;
        private Dictionary<Type, IGarbageDisposalStrategy> dictionaryStrategies;

        [SetUp]
        public void TestInit()
        {
            disposalStrategy = new BurnableStrategy();
            dictionaryStrategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        [Test]
        public void TestPropertyForReadOnlyCollection()
        {
            //Arrange
            IStrategyHolder strategyHolder = new StrategyHolder(dictionaryStrategies);

            //Act
            Type type = strategyHolder.GetDisposalStrategies.GetType();

            //Assert
            var test = type.GetInterfaces();
            Assert.IsTrue(type.GetInterfaces().Contains(typeof(IReadOnlyCollection<>)));
        }

        [Test]
        public void AddStrategy()
        {
            //Arrange
            Type attributeType = typeof(DisposableAttribute);
            IStrategyHolder strategyHolder = new StrategyHolder(dictionaryStrategies);

            //Assert
            Assert.IsTrue(strategyHolder.AddStrategy(attributeType, disposalStrategy));
        }

        [Test]
        public void AddSameStrategy()
        {
            //Arrange
            Type attributeType = typeof(DisposableAttribute);
            IStrategyHolder strategyHolder = new StrategyHolder(dictionaryStrategies);

            //Act
            bool addingOnes = strategyHolder.AddStrategy(attributeType, disposalStrategy);
            bool addingTwice = strategyHolder.AddStrategy(attributeType, disposalStrategy);
            bool addingThirdTime = strategyHolder.AddStrategy(attributeType, disposalStrategy);

            //Assert
            Assert.AreEqual(1, strategyHolder.GetDisposalStrategies.Count);
        }

        [Test]
        public void AddMultipleStrategies()
        {
            //Arrange
            Type attributeTypeBurn = typeof(BurnableAttribute);
            Type attributeTypeStor = typeof(StorableAttribute);
            Type attributeTypeRecyc = typeof(RecyclableAttribute);
            IStrategyHolder strategyHolder = new StrategyHolder(dictionaryStrategies);

            //Act
            bool addingFirst = strategyHolder.AddStrategy(attributeTypeBurn, disposalStrategy);
            bool addingSecond = strategyHolder.AddStrategy(attributeTypeStor, disposalStrategy);
            bool addingThird = strategyHolder.AddStrategy(attributeTypeRecyc, disposalStrategy);

            //Assert
            Assert.AreEqual(3, strategyHolder.GetDisposalStrategies.Count);
        }

        [Test]
        public void RemoveStrategy()
        {
            //Arrange
            Type attributeTypeBurn = typeof(BurnableAttribute);
            IStrategyHolder strategyHolder = new StrategyHolder(dictionaryStrategies);

            //Act
            bool adding = strategyHolder.AddStrategy(attributeTypeBurn, disposalStrategy);

            //Assert
            Assert.IsTrue(strategyHolder.RemoveStrategy(attributeTypeBurn));
        }

        [Test]
        public void RemoveStrategyCheckCount()
        {
            //Arrange
            Type attributeTypeBurn = typeof(BurnableAttribute);
            Type attributeTypeStor = typeof(StorableAttribute);
            Type attributeTypeRecyc = typeof(RecyclableAttribute);
            IStrategyHolder strategyHolder = new StrategyHolder(dictionaryStrategies);

            //Act
            bool addingFirst = strategyHolder.AddStrategy(attributeTypeBurn, disposalStrategy);
            bool addingSecond = strategyHolder.AddStrategy(attributeTypeStor, disposalStrategy);
            bool addingThird = strategyHolder.AddStrategy(attributeTypeRecyc, disposalStrategy);

            bool removing = strategyHolder.RemoveStrategy(attributeTypeBurn);

            //Assert
            Assert.AreEqual(2, strategyHolder.GetDisposalStrategies.Count);
        }
    }
}
