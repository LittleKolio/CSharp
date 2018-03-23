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
                default: throw new ArgumentException("Invalid Layout Type!");
            }
        }
    }
}
