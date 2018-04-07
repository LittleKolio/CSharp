namespace NUnitTest
{
    using Exercise_02_Extended_Database;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestPeopleDatabase
    {
        [Test]
        [TestCase(30)]
        [TestCase(6)]
        [TestCase(0)]
        [TestCase(17)]
        [TestCase(15)]
        public void Exception_Constructor_ThrowExMessage(int capacity)
        {
            //Arrange
            Person[] people = new Person[capacity];
            Func<int, string> name = num => ((char)(97 + num)).ToString();
            for (int i = 0; i < capacity; i++)
            {
                people[i] = new Person(i + 1, name(i));
            }

            //Act
            //InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
            //    () => new Database(args));

            //Assert
            //Assert.AreEqual("Capacity is not 16!", ex.Message);

            Assert.That(() => new PeopleDatabase(people),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Capacity is not 16!"));
        }

        [Test]
        public void Exception_Remove_ThrowExMessage()
        {
            //Arrange
            PeopleDatabase peopleDatabase = new PeopleDatabase();

            //Assert
            Assert.That(() => peopleDatabase.Remove(),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("There is no people!"));
        }

        [Test]
        public void Exception_Add_OverFowThrowExMessage()
        {
            //Arrange
            int capacity = 16;
            Person[] people = new Person[capacity];

            int id = 0;
            Func<int, string> name = num => ((char)(97 + num)).ToString();

            for (int i = 0; i < capacity; i++)
            {
                id = i + 1;
                people[i] = new Person(i + 1, name(i));
            }
            PeopleDatabase peopleDatabase = new PeopleDatabase(people);

            //Act
            Person person = new Person(id + 1, name(id));

            //Assert
            Assert.That(() => peopleDatabase.Add(person),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Capacity limit has been reached!"));
        }

        [Test]
        public void Exception_FindById_InvalidIdThrowExMessage()
        {
            //Arrange
            int capacity = 16;
            Person[] people = new Person[capacity];

            int id = 0;
            Func<int, string> name = num => ((char)(97 + num)).ToString();

            for (int i = 0; i < capacity; i++)
            {
                id = i + 1;
                people[i] = new Person(id, name(i));
            }
            PeopleDatabase peopleDatabase = new PeopleDatabase(people);

            //Assert
            Assert.That(() => peopleDatabase.FindById(id + 1),
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"No user found with id:{id + 1}"));
        }

        [Test]
        public void Exception_FindById_NegativeIdThrowExMessage()
        {
            //Arrange
            long negativeId = -1;
            PeopleDatabase peopleDatabase = new PeopleDatabase();

            //Assert
            Assert.That(() => peopleDatabase.FindById(negativeId),
                Throws.ArgumentException
                    .With.Message.EqualTo("Id cannot be negative!"));
        }

        [Test]
        public void Exception_FindByUsername_ThrowExMessage()
        {
            //Arrange
            int capacity = 16;
            Person[] people = new Person[capacity];

            int id = 0;
            Func<int, string> name = num => ((char)(97 + num)).ToString();

            for (int i = 0; i < capacity; i++)
            {
                id = i + 1;
                people[i] = new Person(id, name(i));
            }
            PeopleDatabase peopleDatabase = new PeopleDatabase(people);
            string invalidName = name(id);

            //Assert
            Assert.That(() => peopleDatabase.FindByUsername(invalidName),
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"No user found with name:{invalidName}"));
        }

        [Test]
        public void Exception_FindByUsername_EmptyStringThrowExMessage()
        {
            //Arrange
            PeopleDatabase peopleDatabase = new PeopleDatabase();
            string invalidName = string.Empty;

            //Assert
            Assert.That(() => peopleDatabase.FindByUsername(invalidName),
                Throws.ArgumentException
                    .With.Message.EqualTo("Username is empty!"));
        }
    }
}
