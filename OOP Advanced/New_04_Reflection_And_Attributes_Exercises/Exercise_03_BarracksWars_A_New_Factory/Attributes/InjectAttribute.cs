namespace Exercise_03_BarracksWars_A_New_Factory.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
    }
}
