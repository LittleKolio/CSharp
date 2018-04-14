namespace RecyclingStation.Models.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

    public class StorableAttribute : DisposableAttribute
    {
        public StorableAttribute(Type type) : base(type)
        {
        }
    }
}
