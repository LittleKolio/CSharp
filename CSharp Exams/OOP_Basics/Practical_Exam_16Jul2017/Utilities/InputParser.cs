using System;
using System.Collections.Generic;
using System.Linq;

public class InputParser
{
    public char[] delimiter = new char[] { ' ' };

    public List<string> ParseInput(string input)
    {
        return new List<string>(
            input.Split(this.delimiter, 
                StringSplitOptions.RemoveEmptyEntries));
    }
}
