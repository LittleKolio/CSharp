namespace Photographers.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class PhotographerContext : DbContext
    {
        public PhotographerContext()
            : base("name=PhotographerContext")
        {
            Database.SetInitializer(
                //new DropCreateDatabaseAlways<PhotographerContext>()
                new MigrateDatabaseToLatestVersion<PhotographerContext, Configuration>()
                );
        }

        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<PhotographerAlbum> PhotographerAlbums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}