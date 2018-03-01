using System.Text;

public class Spy : Soldier, ICodeNumber
{
    public int CodeNumber { get; set; }

    public Spy(
        int id, 
        string firstname, 
        string lastname, 
        double salary, 
        int codeNumber) 
        : base(id, firstname, lastname, salary)
    {
        this.CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
        .AppendLine($"Code Number: {this.CodeNumber}");

        return sb.ToString().TrimEnd();
    }
}