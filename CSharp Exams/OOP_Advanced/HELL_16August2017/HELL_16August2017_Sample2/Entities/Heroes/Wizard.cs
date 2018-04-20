public class Wizard : AbstractHero
{
    private const int strength = 25;
    private const int agility = 25;
    private const int intelligence = 100;
    private const int hitPoints = 100;
    private const int damage = 250;

    public Wizard(string name) 
        : base(name,  strength, agility, intelligence, hitPoints, damage)
    {
    }
}