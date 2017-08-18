namespace RecyclingStation
{
    using Core;
    using Factory;
    using Interfaces;
    using IO;
    using System;
    using System.Collections.Generic;
    using WasteDisposal;
    using WasteDisposal.Interfaces;

    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            IReader read = new Reader();
            IWriter write = new Writer();

            IStrategyHolder strategy = new StrategyHolder(
                new Dictionary<Type, IGarbageDisposalStrategy>()
                );
            IGarbageProcessor processor = new GarbageProcessor(strategy);
            IWasteFactory factory = new WasteFactory();

            IRecyclingManager station = new RecyclingManager(processor, factory);

            Engin engine = new Engin(read, write, station);
            engine.Run();
        }
    }
}
