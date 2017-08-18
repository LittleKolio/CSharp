namespace RecyclingStation.WasteDisposal.Attributes
{
    using System;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>
    
    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
        private Type type;
        public DisposableAttribute(Type type)
        {
            this.Type = type;
        }
        public Type Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }
    } 
}
