public class GoldenEditionBook : Book
{
    public override decimal Price
    {
        get { return base.Price * 1.3M; }
        set { base.Price = value; }
    }

    public GoldenEditionBook(string title, string author, decimal price) 
        : base (title, author, price)
    {
    }
}
