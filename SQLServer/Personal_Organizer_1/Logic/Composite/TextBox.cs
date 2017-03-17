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
            var label_x = (width - content.Length) / 2 + x;
            var label_y = (height - 1) / 2 + y;
            this.label = new Label(label_x, label_y, content);

            this.layout = new Layout(x, y);
            this.layout.SetLayout(
                Composer.Compose(Composer.GetBox(width, height))
                );
        }

        public override void Print()
        {
            this.layout.Print();
            this.label.Print();
        }
    }
}
