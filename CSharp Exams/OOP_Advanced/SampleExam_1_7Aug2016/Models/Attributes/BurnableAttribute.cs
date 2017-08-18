namespace RecyclingStation.Models.Attributes
{
    using RecyclingStation.WasteDisposal.Attributes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BurnableAttribute : DisposableAttribute
    {
        public BurnableAttribute(Type type) : base(type)
        {
        }
    }
}
