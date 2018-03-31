using System;

namespace Logger
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout": return new SimpleLayout();
                case "XmlLayout": return new XmlLayout();
                default: throw new ArgumentException("Invalid Layout Type!");
            }
        }
    }
}
