namespace SampleExam_1_7Aug2016.WasteDisposal.Attributes
{
    using System;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>
    
    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
    }
}
