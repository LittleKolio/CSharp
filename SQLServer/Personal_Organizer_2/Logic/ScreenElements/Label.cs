namespace Logic.ScreenElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Label : ScreenElement
    {
        private string content;

        public Label(int x, int y, string content) 
            : base(x, y)
        {
            this.content = content;
        }

        protected override void Render()
        {
            Console.CursorLeft += this.x;
            Console.CursorTop += this.y;
            Console.Write(this.content);
        }
    }
}
