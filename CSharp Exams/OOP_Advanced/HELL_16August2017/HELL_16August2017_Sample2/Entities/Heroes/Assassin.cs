public class Assassin : AbstractHero
{
    private const int strength = 25;
    private const int agility = 100;
    private const int intelligence = 15;
    private const int hitPoints = 150;
    private const int damage = 300;

    public Assassin(string name) 
        : base(name,  strength, agility, intelligence, hitPoints, damage)
    {
    }
}