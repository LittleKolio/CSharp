using System;

public class Card : IComparable<Card>
{
    public Card(string suit, string rank)
    {
        this.Suit = (CardSuits)Enum.Parse(typeof(CardSuits), suit);
        this.Rank = (CardRanks)Enum.Parse(typeof(CardRanks), rank);
    }
    public CardSuits Suit { get; private set; }
    public CardRanks Rank { get; private set; }
    public int Power
    {
        get { return (int)this.Rank + (int)this.Suit; }
    }
    public string Name
    {
        get { return $"{this.Rank} of {this.Suit}"; }
    }

    public override string ToString()
    {
        return $"Card name: {this.Name}; " +
            $"Card power: {this.Power}";
    }

    public int CompareTo(Card other)
    {
        return this.Power - other.Power;
    }
}