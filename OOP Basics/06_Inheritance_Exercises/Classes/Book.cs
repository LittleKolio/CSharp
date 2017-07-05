using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Inheritance_Exercises.Classes
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get { return this.title; }
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
            get { return this.author; }
            set
            {
                string[] names = value
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (Regex.IsMatch(names[1], @"^\d"))
                {
                    throw new ArgumentException(
                        "Author not valid!");
                }
                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            set
            {
                if (value.ToString().Split('.')[1].Length > 2)
                {
                    throw new ArgumentException(
                        "Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: ").AppendLine(this.GetType().Name)
                .Append("Title: ").AppendLine(this.Title)
                .Append("Author: ").AppendLine(this.Author)
                .Append("Price: ").Append($"{this.Price:F1}")
                .AppendLine();

            return sb.ToString();

        }

    }
}
