class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.age = age;
        this.firstName = firstName;
        this.lastName = lastName;
        this.salary = salary;
    }

    public int Age
    {
        get { return this.age; }
    }

    public string FirstName
    {
        get { return this.firstName; }
    }

    public void IncreaseSalary(double percent)
    {
        if (this.age < 30)
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
        return $"{this.firstName} {this.lastName} is a {this.age} years old";
        //return $"{this.firstName} {this.lastName} get {this.salary:F2} leva";
    }
}

