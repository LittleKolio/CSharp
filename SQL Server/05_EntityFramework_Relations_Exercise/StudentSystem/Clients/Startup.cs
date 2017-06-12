namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Data;

    class Startup
    {
        static void Main()
        {
            var context = new StudentSystemContext();
            context.Database.Initialize(true);
        }
    }
}
