namespace Logic.ScreenElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Layout : ScreenElement
    {
        private string[] layout;
        public Layout(int x, int y) : base(x, y)
        {
        }

        public void SetLayout(string[] layout)
        {
            this.layout = layout;
        }

        protected override void Render()
        {
            Console.CursorLeft += this.x;
            Console.CursorTop += this.y;

            for (int row = 0; row < this.layout.Length; row++)
            {
                Console.Write(this.layout[row]);
                Console.CursorLeft -= this.layout[row].Length;
                Console.CursorTop++;
            }
        }
    }
}
