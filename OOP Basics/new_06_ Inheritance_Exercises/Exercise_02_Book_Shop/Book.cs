using System;
using System.Linq;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException(
                    "Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            if (ValidateAuthor(value))
            {
                throw new ArgumentException(
                    "Author not valid!");
            }
            this.author = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "Price not valid!");
            }
            this.price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    private bool ValidateAuthor(string author)
    {
        string[] name = author.Split(new[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        char first = name[1][0];
        return Char.IsDigit(first);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        return sb.ToString().TrimEnd();
    }
}
