namespace RecyclingStation.Models.Attributes
{
    using System;
    using RecyclingStation.WasteDisposal.Attributes;

    public class RecyclableAttribute : DisposableAttribute
    {
        public RecyclableAttribute(Type type) : base(type)
        {
        }
    }
}
