namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using System.Linq;

    public class Stage : IStage
    {
        //public readonly List<ISet> sets;
        //public readonly List<ISong> songs;
        //public readonly List<IPerformer> performers;

        private List<ISet> sets;
        private List<ISong> songs;
        private List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers
                .FirstOrDefault(p => p.Name == name);

            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets
                .FirstOrDefault(s => s.Name == name);

            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs
                .FirstOrDefault(s => s.Name == name);

            return song;
        }

        public bool HasPerformer(string name)
        {
            IPerformer performer = this.performers
                .FirstOrDefault(p => p.Name == name);

            return performer != null;
        }

        public bool HasSet(string name)
        {
            ISet set = this.sets
                .FirstOrDefault(s => s.Name == name);

            return set != null;
        }

        public bool HasSong(string name)
        {
            ISong song = this.songs
                .FirstOrDefault(s => s.Name == name);

            return song != null;
        }
    }
}
