
namespace Logic.ScreenElements
{
    using System.Collections.Generic;

    class ScreenElementsColection
    {
        private List<ScreenElement> content;

        public ScreenElementsColection(List<ScreenElement> content)
        {
            this.content = content;
        }

        public void Print()
        {
            foreach (var el in content)
            {
                el.Print();
            }
        }
    }
}
