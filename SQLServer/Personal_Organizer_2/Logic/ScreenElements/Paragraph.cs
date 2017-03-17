namespace Logic.ScreenElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Paragraph : ScreenElement
    {
        private List<string> content;
        public Paragraph(int x, int y, List<string> content) 
            : base(x, y)
        {
            this.content = content;
        }

        protected override void Render()
        {
            Console.CursorLeft += this.x;
            Console.CursorTop += this.y;

            for (int row = 0; row < this.content.Count; row++)
            {
                Console.Write(this.content[row]);
                Console.CursorLeft -= this.content[row].Length;
                Console.CursorTop++;
            }
        }
    }
}
