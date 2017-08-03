using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    private const string CLASS_INFO = "Class under investigation: {0}";
    private const string FIELD_INFO = "{0} = {1}";


    public string StealFieldInfo(string className, params string[] fildsNames)
    {
        StringBuilder sb = new StringBuilder();

        Type hacker = Type.GetType(className);

        sb.AppendLine(string.Format(CLASS_INFO, hacker.Name));

        FieldInfo[] fields = hacker.GetFields(
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static
            );

        Object classInstance = Activator.CreateInstance(hacker, new object[] { });

        foreach (FieldInfo field in fields)
        {
            string name = field.Name;
            if (fildsNames.Contains(name))
            {
                sb.AppendLine(string.Format(FIELD_INFO, name, field.GetValue(classInstance)));
            }
        }

        return sb.ToString().Trim();
    }
}