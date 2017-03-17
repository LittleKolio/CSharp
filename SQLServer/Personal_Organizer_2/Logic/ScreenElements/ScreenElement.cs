namespace Logic.ScreenElements
{
    using System;
    using Utilities;
    public abstract class ScreenElement
    {
        protected int x;
        protected int y;
        private int startingX;
        private int startingY;

        private ConsoleColor background;
        private ConsoleColor foreground;

        public ScreenElement(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.background = ConsoleConfig.defBackground;
            this.foreground = ConsoleConfig.defForegound;
        }

        public virtual ConsoleColor Background
        {
            get { return this.background; }
            set { this.background = value; }
        }
        public virtual ConsoleColor Foreground
        {
            get { return this.foreground; }
            set { this.foreground = value; }
        }
        public void Print(bool hightlight = false)
        {
            if (hightlight)
            {
                Console.BackgroundColor = this.foreground;
                Console.ForegroundColor = this.background;
            }
            else
            {
                Console.BackgroundColor = this.background;
                Console.ForegroundColor = this.foreground;
            }

            this.StartPrint();
            this.Render();
            this.EndPrint();

            if (hightlight)
            {
                Console.BackgroundColor = this.background;
                Console.ForegroundColor = this.foreground;
            }
        }

        protected abstract void Render();

        private void StartPrint()
        {
            this.startingX = Console.CursorLeft;
            this.startingY = Console.CursorTop;
        }
        private void EndPrint()
        {
            Console.CursorLeft = this.startingX;
            Console.CursorTop = this.startingY;
        }
    }
}
