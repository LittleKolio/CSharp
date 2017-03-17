namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using Input;
    using ScreenElements;
    using Data;

    public abstract class ScreenController
    {
        private DbContext context;
        private KeyboardInput parser;
        protected ScreenElement root; // protected ??

        public ScreenController(
            OrganizerEntities context, 
            KeyboardInput parse, 
            ScreenElement root
            )
        {
            this.context = context;
            this.parser = parse;
            this.root = root;
        }

        public ScreenController(OrganizerEntities context, KeyboardInput parse)
        {
            this.context = context;
            this.parser = parse;
        }

        public void Print()
        {
            this.root.Print();
        }

        public void BeginParse()
        {
            this.Print();
            this.parser.Listen();
        }
    }
}
