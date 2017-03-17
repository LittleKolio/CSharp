namespace Logic.Composite
{
    using ScreenElements;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Utilities;

    public class TextBox
        : ScreenElement
    {
        private Layout layout;
        private Label label;
        public TextBox(int x, int y, int width, int height, string content) 
            : base(x, y)
        {
            var labelX = (width - content.Length) / 2; //bez + x
            var labelY = (height - 1) / 2; //bez + y
            this.label = new Label(labelX, labelY, content);

            this.layout = new Layout(0, 0);
            this.layout.SetLayout(
                Composer.Compose(Composer.GetBox(width, height))
                );
        }

        protected override void Render()
        {
            Console.CursorLeft += this.x;
            Console.CursorTop += this.y;
            this.layout.Print();
            this.label.Print();
        }
    }
}
