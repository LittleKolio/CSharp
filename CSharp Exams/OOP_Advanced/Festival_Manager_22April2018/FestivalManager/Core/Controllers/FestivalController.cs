namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using Entities.Factories.Contracts;
    using Entities;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";

		private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;

        public FestivalController(
            IStage stage, 
            IInstrumentFactory instrumentFactory, 
            ISetFactory setFactory)
		{
			this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.setFactory = setFactory;
        }

		public string ProduceReport()
		{
            StringBuilder result = new StringBuilder();

            TimeSpan totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result.AppendFormat("Festival length: {0}" + Environment.NewLine,
                totalFestivalLength.ToString(TimeFormat));

            foreach (var set in this.stage.Sets)
            {
                result.AppendFormat("--{0} ({1}):" + Environment.NewLine,
                    set.Name, set.ActualDuration.ToString(TimeFormat));

                foreach (IPerformer performer in set.Performers.OrderByDescending(p => p.Age))
                {
                    string instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendFormat("---{0} ({1})" + Environment.NewLine,
                        performer.Name, instruments);
                }

                if (!set.Songs.Any())
                {
                    result.AppendLine("--No songs played");
                }
                else
                {
                    result.AppendLine("--Songs played:");
                    foreach (ISong song in set.Songs)
                    {
                        result.AppendFormat("----{0} ({1})" + Environment.NewLine,
                            song.Name, song.Duration.ToString(TimeFormat));
                    }
                }
            }

            return result.ToString();
        }

        public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return string.Format("Registered {0} set", type);
		}

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            string[] instruments = args.Skip(2).ToArray();

            IPerformer performer = new Performer(name, age);

            foreach (string instrumentType in instruments)
            {
                IInstrument instrument = this.instrumentFactory.CreateInstrument(instrumentType);
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return "Registered performer " + performer.ToString();
        }

        public string RegisterSong(string[] args)
		{
            string name = args[0];
            string timeSpan = args[1];

            TimeSpan duration;
            TimeSpan.TryParseExact(timeSpan, TimeFormat, null, out duration);

            ISong song = new Song(name, duration);

            this.stage.AddSong(song);

            return "Registered song " + song.ToString();

        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(
                    "Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(
                    "Invalid song provided");
            }

            ISet set = this.stage.GetSet(setName);
            ISong song = this.stage.GetSong(songName);

            set.AddSong(song);

            return string.Format("Added {0} to {1}", song.ToString(), set.Name);
        }

        public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException(
                    "Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException(
                    "Invalid set provided");
			}

			IPerformer performer = this.stage.GetPerformer(performerName);
			ISet set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return string.Format("Added {0} to {1}", performer.Name, set.Name);
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return string.Format("Repaired {0} instruments", instrumentsToRepair.Length);
		}

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}