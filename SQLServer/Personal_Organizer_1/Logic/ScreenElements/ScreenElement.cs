namespace Logic.ScreenElements
{
    using System;
    public abstract class ScreenElement
    {
        protected int x;
        protected int y;

        public ScreenElement(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract void Print();
    }
}
