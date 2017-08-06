using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class DatabaseTest
{
    [Test]
    [TestCase(6)]
    public void Constructor(int num)
    {
        //Arrange
        List<int> elements = new List<int>();
        for (int i = 0; i < num; i++)
        {
            elements.Add(i);
        }

        //Act
        Database db = new Database(elements);

        //Assert
        Assert.AreEqual(num, db.Count);
    }

    [Test]
    [TestCase(32)]
    public void ConstructorOverCapacity(int num)
    {
        //Arrange
        List<int> elements = new List<int>();
        for (int i = 0; i < num; i++)
        {
            elements.Add(i);
        }

        //Assert
        Assert.Throws<InvalidOperationException>(
            () => new Database(elements),
            "The size of the array is in range"
            );
    }

    [Test]
    public void AddElement()
    {
        //Arrange
        Database db = new Database(new List<int>() { 1 });

        //Act
        db.Add(2);

        //Assert
        Assert.AreEqual(2, db.Count);
    }

    [Test]
    [TestCase(4)]
    public void AddSomeElement(int num)
    {
        //Arrange
        Database db = new Database(new List<int>() { 1 });

        //Act
        for (int i = 0; i < num; i++)
        {
            db.Add(i);
        }
       
        //Assert
        Assert.AreEqual(num + 1, db.Count);
    }

    [Test]
    [TestCase(16)]
    public void AddElementOverCapacity(int num)
    {
        //Arrange
        List<int> elements = new List<int>();
        for (int i = 0; i < num; i++)
        {
            elements.Add(i);
        }
        Database db = new Database(elements);

        //Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Add(5)
            );
    }

    [Test]
    public void GetCollection()
    {
        //Arrange
        Database db = new Database(new List<int>() { 1, 90 });

        //Act
        db.Add(6);

        //Assert
        CollectionAssert.AreEqual(new int[] { 1, 90, 6 }, db.Fech());
    }


    [Test]
    public void RemoveElement()
    {
        //Arrange
        Database db = new Database(new List<int>() { 1, 90, 76, 2});

        //Act
        db.Remove();

        //Assert
        Assert.AreEqual(3, db.Count);
    }

    [Test]
    public void RemoveElementUnderCapacity()
    {
        //Arrange
        Database db = new Database(new List<int>() { 1, 90, 76, 2 });

        //Act
        db.Remove();
        db.Remove();
        db.Remove();
        db.Remove();

        //Assert
        Assert.Throws<InvalidOperationException>(
            () => db.Remove()
            );
    }
}