using Exercise_01_Database;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NUnitTest
{
    public class TestDatabase
    {
        [Test]
        public void Constructor_CreateArray()
        {
            //Arrange
            int capacity = 16;
            int[] args = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                args[i] = i + 1;
            }

            //Act
            Database data = new Database(args);

            //Assert
            FieldInfo fieldInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == typeof(IList<int>));
            IList<int> fieldValues = (IList<int>)fieldInfo.GetValue(data);

            Assert.That(fieldValues,Is.EquivalentTo(args));
        }

        [Test]
        [TestCase(30)]
        [TestCase(6)]
        [TestCase(0)]
        [TestCase(17)]
        [TestCase(15)]
        public void Exception_ConstructorThrowExMessage(int capacity)
        {
            //Arrange
            int[] args = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                args[i] = i + 1;
            }

            //Act
            //InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
            //    () => new Database(args));

            //Assert
            //Assert.AreEqual("Capacity is not 16!", ex.Message);

            Assert.That(() => new Database(args),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Capacity is not 16!"));
        }


        [Test]
        public void Exception_RemoveThrowExMessage()
        {
            //Arrange
            Database data = new Database();

            //Assert
            Assert.That(() => data.Remove(),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("There is no integers!"));
        }

        [Test]
        public void Exception_AddThrowExMessage()
        {
            //Arrange
            int capacity = 16;
            int[] args = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                args[i] = i + 1;
            }
            Database data = new Database(args);

            int elemetToAdd = capacity + 1;

            //Assert
            Assert.That(() => data.Add(elemetToAdd),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Capacity limit has been reached!"));
        }

        [Test]
        public void Constructor_CreateEmptyCollection()
        {
            //Act
            Database data = new Database();

            //Assert
            Assert.That(data.Count == 0);
        }

        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(16)]
        public void Add_ElementsToCollection(int count)
        {
            //Arrange
            int number;
            Database data = new Database();

            //Act
            for (number = 1; number <= count; number++)
            {
                data.Add(number);
            }

            //Assert
            Assert.That(data.Count == count);
        }

        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(16)]
        public void Remove_ElementsFromCollection(int count)
        {
            //Arrange
            int capacity = 16;
            int[] args = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                args[i] = i + 1;
            }
            Database data = new Database(args);

            //Act
            for (int i = 0; i < count; i++)
            {
                data.Remove();
            }

            //Assert
            Assert.That(data.Count == capacity - count);
        }


    }
}
