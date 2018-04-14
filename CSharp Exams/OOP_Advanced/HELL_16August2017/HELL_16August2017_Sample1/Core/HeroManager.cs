using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    private Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            ConstructorInfo[] constructors = clazz.GetConstructors();
            IHero hero = (IHero) constructors[0].Invoke(new object[] {heroName});
            this.heroes.Add(hero.Name, hero);

            result = string.Format(
                Constants.HeroCreateMessage, 
                heroType, 
                hero.GetType().Name
                );
        }
        catch (Exception e)
        {
            result = e.Message;
        }

        return result;
    }

    public string AddItem(IList<string> arguments)
    {
        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IItem newItem = new CommonItem(
            itemName, 
            strengthBonus, 
            agilityBonus, 
            intelligenceBonus, 
            hitPointsBonus,
            damageBonus
            );

        this.heroes[heroName].AddItem(newItem);

        return string.Format(
            Constants.ItemCreateMessage, 
            newItem.Name, 
            heroName
            );
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit(IList<string> arguments)
    {
        throw new NotImplementedException();
    }

    public string AddRecipe(IList<string> arguments)
    {
        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        List<string> requiredItems = arguments.Skip(7).ToList();

        IRecipe newRecipe = new RecipeItem(
            itemName,
            strengthBonus,
            agilityBonus,
            intelligenceBonus,
            hitPointsBonus,
            damageBonus,
            requiredItems
            );

        this.heroes[heroName].AddRecipe(newRecipe);

        return string.Format(
            Constants.RecipeCreatedMessage,
            newRecipe.Name,
            heroName
            );
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
}