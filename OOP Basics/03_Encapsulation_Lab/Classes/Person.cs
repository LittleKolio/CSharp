using System;

class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age)
    {
        this.Age = age;
        this.FirstName = firstName;
        this.LastName = lastName;
    }
    public Person(string firstName, string lastName, int age, double salary)
        : this(firstName, lastName, age)
    {
        this.Salary = salary;
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException(
                    "Age cannot be zero or negative integer");
            }
            this.age = value;
        }
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException(
                    "First name cannot be less than 3 symbols");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException(
                    "Last name cannot be less than 3 symbols");
            }
            this.lastName = value;
        }
    }

    public double Salary
    {
        get { return this.salary; }
        set
        {
            if (value < 460.0)
            {
                throw new ArgumentException(
                    "Salary cannot be less than 460 leva");
            }
            this.salary = value;
        }
    }

    public void IncreaseSalary(double percent)
    {
        if (this.Age < 30)
        {
            this.salary += this.salary * percent / 200;
        }
        else
        {
            this.salary += this.salary * percent / 100;
        }
    }

    public override string ToString()
    {
        //return $"{this.firstName} {this.lastName} is a {this.age} years old";
        return $"{this.firstName} {this.lastName} get {this.salary:F2} leva";
    }
}

