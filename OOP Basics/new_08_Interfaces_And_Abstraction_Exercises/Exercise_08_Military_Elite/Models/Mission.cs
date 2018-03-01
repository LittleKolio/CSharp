using System;
using System.Collections.Generic;

public class Mission : IMission
{
    private List<string> availableStates = new List<string> { "inProgress", "Finished" };
    private string state;

    public string CodeName { get; set; }
    public string State
    {
        get { return this.state; }
        set
        {
            if (!availableStates.Contains(value))
            {
                throw new ArgumentException();
            }
            this.state = value;
        }
    }

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}