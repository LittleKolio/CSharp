namespace Logic
{
    using System;
    using System.Collections.Generic;
    using Data;
    using ScreenElements;
    using Utilities;
    using Composite;
    using Input;

    class Startup
    {
        static void Main()
        {
            var ctx = new OrganizerEntities();
            //ctx.Database.Initialize(true);

            Console.CursorVisible = false;
            ConsoleConfig.defBackground = ConsoleColor.Black;
            ConsoleConfig.defForegound = ConsoleColor.Gray;

            var app = new HomeScreenController(ctx, new KeyboardInput());
            app.BeginParse();
        }
    }
}
