public class Player
{
    private Card[] hand;
    public Player(string name)
    {
        this.Name = name;
        this.hand = new Card[5];
    }

    public string Name { get; private set; }

    public void AddCard(Card card)
    {

    }
}