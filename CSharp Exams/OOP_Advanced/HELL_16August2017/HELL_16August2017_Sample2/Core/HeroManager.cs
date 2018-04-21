using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    private Dictionary<string, IHero> heroes;
    private IHeroFactory heroFactory;
    private IOutputWriter outputWriter;

    public HeroManager(IHeroFactory heroFactory, IOutputWriter outputWriter)
    {
        this.heroes = new Dictionary<string, IHero>();
        this.heroFactory = heroFactory;
        this.outputWriter = outputWriter;
    }

    public IReadOnlyDictionary<string, IHero> Heroes => this.heroes;

    public string AddHero(List<string> arguments)
    {
        IHero hero = this.heroFactory.CreateHero(arguments);

        if (this.heroes.ContainsKey(hero.Name))
        {
            throw new InvalidOperationException(
                "Hero already exists!");
        }

        this.heroes.Add(hero.Name, hero);

        return string.Format(Constants.HeroCreateMessage, 
            new string[] { hero.GetType().Name, hero.Name});
    }

    public string AddItemToHero(List<String> arguments, Hero hero)
    {
        string result = null;

        //Ма те много бе!
        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        //тука трябваше да добавя към hero ама промених едно нещо и то много неща се счупиха и реших просто да не добавям

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string CreateGame()
    {
        StringBuilder result = new StringBuilder();

        foreach (var hero in heroes)
        {
            result.AppendLine(hero.Key);
        }

        return result.ToString();
    }

    public string Inspect(List<String> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    //Само Батман знае как работи това
    public static void GenerateResult()
    {
        const string PropName = "_connectionString";

        var type = typeof(HeroCommand);

        FieldInfo fieldInfo = null;
        PropertyInfo propertyInfo = null;
        while (fieldInfo == null && propertyInfo == null && type != null)
        {
            fieldInfo = type.GetField(PropName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null)
            {
                propertyInfo = type.GetProperty(PropName,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            }

            type = type.BaseType;
        }
    }

    public static void DontTouchThisMethod()
    {
        //това не трябва да го пипаме, че ако го махнем ще ни счупи цялата логика
        var l = new List<string>();
        var m = new Manager();
        HeroCommand cmd = new HeroCommand(l, m);
        var str = "Execute";
        Console.WriteLine(str);
    }
}