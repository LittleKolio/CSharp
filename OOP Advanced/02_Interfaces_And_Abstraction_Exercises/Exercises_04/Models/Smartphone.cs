using System;
using System.Text.RegularExpressions;

public class Smartphone : ICalling, IBrowsing
{
    private string site;
    private string number;

    public string Number
    {
        get { return this.number; }
        set
        {
            if (Regex.IsMatch(value, "[^\\d]+"))
            {
                throw new ArgumentException(
                    "Invalid number!");
            }
            this.number = value;
        }
    }
    public string Site
    {
        get { return this.site; }
        set
        {
            if (Regex.IsMatch(value, "\\d+") || 
                string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Invalid URL!");
            }
            this.site = value;
        }
    }

    public string CallOtherPhones()
    {
        return $"Calling... {this.Number}";
    }

    public string WorldWideWeb()
    {
        return $"Browsing: {this.Site}!";
    }
}
