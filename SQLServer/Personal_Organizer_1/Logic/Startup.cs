namespace Logic
{
    using System;
    using System.Collections.Generic;
    using Data;
    using ScreenElements;
    using Utilities;
    using Composite;

    class Startup
    {
        static void Main()
        {
            //var ctx = new OrganizerEntities();
            //ctx.Database.Initialize(true);


            //tarsim simvoli
            //for (int i = 0; i < 255; i++)
            //{
            //    Console.Write($"{i,4}:{(char)i,-4}");
            //    if (i % 7 == 0) { Console.WriteLine(); }
            //}
            //Console.WriteLine((char)9559);

            Console.CursorVisible = false;


            //var p = new List<string>();
            //p.Add("e'prtg peor ,iopt,");
            //p.Add("stopyiy,'.r69,cs['k");
            //p.Add("er;,t2[0435,ucosw,u 9u");

            //var layout = new Layout(4, 2);
            //layout.SetLayout(Composer.Compose(Composer.GetBox(30, 10)));

            //var list = new List<ScreenElement>();
            //ramkata e parva za6oto otpe4atva orazni mesta posredata
            //list.Add(layout);
            //list.Add(new Label(6, 4, "sdfasdfasdf"));
            //list.Add(new Label(6, 5, "sdfasdfasdf"));
            ////list.Add(new Paragraph(5, 15, p));


            //var mee = new ScreenElementsColection(list);
            //mee.Print();


            var textBox = new TextBox(4, 2, 13, 3, "Hello, tui!");
            var list = new List<ScreenElement>();
            list.Add(textBox);
            list.Add(new Label(5, 5, "sdfasdfasdf"));
            list.Add(new Label(5, 6, "sdfasdfasdf"));

            var mee = new ScreenElementsColection(list);
            mee.Print();

            Console.ReadKey(true);
        }
    }
}
