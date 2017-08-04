using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    private const string CLASS_INFO = "Class under investigation: {0}";
    private const string FIELD_INFO = "{0} = {1}";

    private const string FIELD_MISTAKE = "{0} must be private!";
    private const string GETTER_MISTAKE = "{0} have to be public!";
    private const string SETTER_MISTAKE = "{0} have to be private!";


    public string StealFieldInfo(string className, params string[] fildsNames)
    {
        StringBuilder sb = new StringBuilder();

        Type hacker = Type.GetType(className);

        sb.AppendLine(string.Format(CLASS_INFO, className));

        FieldInfo[] fields = hacker.GetFields(
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static
            );

        Object classInstance = Activator.CreateInstance(hacker, new object[] { });

        foreach (FieldInfo field in 
            fields.Where(f => fildsNames.Contains(f.Name)))
        {
            sb.AppendLine(string.Format(FIELD_INFO, field.Name, field.GetValue(classInstance)));
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type hacker = Type.GetType(className);

        FieldInfo[] fields = hacker.GetFields(
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static
            );
        MethodInfo[] propsSetter = hacker.GetMethods(
            BindingFlags.Public |
            BindingFlags.Instance
            );
        MethodInfo[] propsGetter = hacker.GetMethods(
            BindingFlags.NonPublic |
            BindingFlags.Instance
            );
        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine(string.Format(FIELD_MISTAKE, field.Name));
        }

        foreach (MethodInfo method in 
            propsGetter.Where(p => p.Name.StartsWith("get")))
        {
            sb.AppendLine(string.Format(GETTER_MISTAKE, method.Name));
        }

        foreach (MethodInfo method in 
            propsSetter.Where(p => p.Name.StartsWith("set")))
        {
            sb.AppendLine(string.Format(SETTER_MISTAKE, method.Name));
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type hacker = Type.GetType(className);

        MethodInfo[] methods = hacker.GetMethods(
            BindingFlags.NonPublic |
            BindingFlags.Instance
            );

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {hacker.BaseType.Name}");

        foreach (MethodInfo method in methods)
        {
            sb.AppendLine(method.Name);
        }
        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type hacker = Type.GetType(className);

        MethodInfo[] methods = hacker.GetMethods(
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Public
            );

        StringBuilder sb = new StringBuilder();

        foreach (MethodInfo method in
            methods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in
            methods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}