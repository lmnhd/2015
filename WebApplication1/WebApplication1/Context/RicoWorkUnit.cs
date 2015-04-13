using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RicoGMB.Context.Entities;

namespace RicoGMB.Context
{
    public static class RicoWorkUnit
    {
        private static RicoContext _context;

         static RicoWorkUnit()
        {
            _context = new RicoContext();
        }

        public static int StoreAlbum(Album album)
        {
            _context._Albums.Add(album);
            _context.SaveChanges();
            return album.Id;
        }
        public static int StoreMixtape(Mixtape mixtape)
        {
            _context._Mixtapes.Add(mixtape);
            _context.SaveChanges();
            return mixtape.Id;
        }
        public static int StoreTrack(Track track)
        {
            _context._Tracks.Add(track);
            _context.SaveChanges();
            return track.Id;
        }
        public static int StoreAlbum(Event newEvent)
        {
            _context._Events.Add(newEvent);
            _context.SaveChanges();
            return newEvent.Id;
        }
        public static int StoreNews(News news)
        {
            _context._Newses.Add(news);
            _context.SaveChanges();
            return news.Id;
        }

        public static int UpdateItem(IItemContainer data)
        {
            var result = 0;
            switch (data.Type)
            {
                    case ItemType.Album:
                    var album = (Album) data;
                    _context.Entry(album).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = album.Id;
                    break;
                    case ItemType.Event:
                    var evt = (Event)data;
                    _context.Entry(evt).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = evt.Id;
                    break;
                    case ItemType.Mixtape:
                    var mt = (Mixtape)data;
                    _context.Entry(mt).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = mt.Id;
                    break;
                    case ItemType.News:
                    var news = (News)data;
                    _context.Entry(news).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = news.Id;
                    break;
                    case ItemType.Track:
                    var trk = (Track)data;
                    _context.Entry(trk).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = trk.Id;
                    break;
                   

            }
            return result;
        }

        public static IEnumerable<Album> GetAlbums()
        {
            return _context._Albums;
        }

        public static IEnumerable<Mixtape> GEtMixtapes()
        {
            return _context._Mixtapes;
        }

        public static IEnumerable<Track> GetTracks()
        {
            return _context._Tracks.Include(t => t.Album);
        }

        public static IEnumerable<Event> GetEvents()
        {
            return _context._Events;
        }

        public static IEnumerable<News> GetNewses()
        {
            return _context._Newses;
        } 
    }
}