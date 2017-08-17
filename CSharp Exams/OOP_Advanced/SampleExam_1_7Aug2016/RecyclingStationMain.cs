namespace RecyclingStation
{
    using Core;
    using Interfaces;
    using IO;
    using System;

    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            IReader read = new Reader();
            IWriter write = new Writer();
            IRecyclingManager station = new RecyclingManager();
            Engin engine = new Engin(read, write, station);
            engine.Run();
        }
    }
}
