public class Barbarian : AbstractHero
{
    private const int strength = 90;
    private const int agility = 25;
    private const int intelligence = 10;
    private const int hitPoints = 350;
    private const int damage = 150;

    public Barbarian(string name) 
        : base(name,  strength, agility, intelligence, hitPoints, damage)
    {
    }
}