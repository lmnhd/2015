using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using RicoGMB.Context.Entities;
using RicoGMB.Models;

namespace RicoGMB.Context
{
    public class RicoContext : DbContext
    {
        public RicoContext() : base("DefaultConnection")
        {
            
        }
       
        public DbSet<Mixtape> _Mixtapes { get; set; }
        public DbSet<Album> _Albums { get; set; }
        public DbSet<News> _Newses { get; set; }
        public DbSet<Track> _Tracks { get; set; }
        public DbSet<Event> _Events { get; set; }

        public DbSet<ArtistGlobals> _Globals { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().HasOptional(t => t.Album);
            base.OnModelCreating(modelBuilder);
        }
    }
}