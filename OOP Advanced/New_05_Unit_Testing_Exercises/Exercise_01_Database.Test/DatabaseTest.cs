using Exercise_01_Database;
using NUnit.Framework;
using System;

[TestFixture]
public class DatabaseTest
{
    [Test]
    public void TestConstructor()
    {
        //Arrange
        Database data = new Database(1, 2, 3, 4, 5);

        //Act
        data.Remove();

        //Assert
        Assert.AreEqual(4, data.Count);
    }
}