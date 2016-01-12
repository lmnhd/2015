using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;
using RicoGMB.Context;
using RicoGMB.Context.Entities;
using RicoGMB.Extensions;

namespace RicoGMB.Controllers
{
  
    public class HomeController : Controller
    {
        private RicoWorkUnit _unit;

        public HomeController()
        {
            _unit = new RicoWorkUnit();
        }
       
        public ActionResult Index()
        {
            //var list = new List<ITileItemContainer>();
            //var songs = GetMusicItems();
            //list.AddRange(GetYouTubePlaylist());
            //list.AddRange(GetNewsItems());
            //list.AddRange(songs);
            //list.Shuffle();
            //ViewBag.videos = GetYouTubePlaylist();
            //ViewBag.tracks = RicoWorkUnit.GetTracks();
            //ViewBag.mixtapes = RicoWorkUnit.GEtMixtapes();
            //ViewBag.events = RicoWorkUnit.GetEvents();
            //ViewBag.news = RicoWorkUnit.GetNewses();
            var instagramlist = RicoGMB.Helpers.DataHelpers.GetInstagramPosts();
            var hpList = new List<IItemContainer>();
            hpList.AddRange(_unit.GEtMixtapes());
            hpList.AddRange(_unit.GetAlbums());
            hpList.AddRange(_unit.GetEvents());
            hpList.AddRange(_unit.GetNewses());
            hpList.AddRange(_unit.GetTracks());
            hpList.AddRange(RicoGMB.Helpers.DataHelpers.GetYouTubePlaylist());
            hpList.AddRange(instagramlist);
           hpList.Sort(new ItemSorter());
            ViewBag.items = hpList;
            //ViewBag.dataobj = JsonConvert.SerializeObject(hpList);

            var json = new
            {
                videos = new List<IItemContainer>(),
                tracks = new List<IItemContainer>(),
                mixtapes = new List<IItemContainer>(),
                albums = new List<IItemContainer>(),
                events = new List<IItemContainer>(),
                newses = new List<IItemContainer>(),
                instagrams = new List<IItemContainer>(),
                globals = _unit.GetGlobals()


            };
            foreach (IItemContainer container in hpList)
            {
                switch (container.Type)
                {
                        case ItemType.Album:
                        json.albums.Add(container);
                        break;
                        case ItemType.Event:
                        json.events.Add(container);
                        break;
                        case ItemType.Instagram:
                        json.instagrams.Add(container);
                        break;
                        case ItemType.Mixtape:
                        var mt = (Mixtape) container;
                        mt.DecodedEmbed =  WebUtility.HtmlDecode(mt.PlayerEmbed);
                        json.mixtapes.Add(mt);
                        break;
                        case ItemType.News:
                        json.newses.Add(container);
                        break;
                        case ItemType.Video:
                        json.videos.Add(container);
                        break;
                        case ItemType.Track:
                        json.tracks.Add(container);
                        break;
                }
            }
            ViewBag.dataobj = JsonConvert.SerializeObject(json);
            
            return View();
        }
        private class ItemSorter : IComparer<IItemContainer>
        {
            public int Compare(IItemContainer x, IItemContainer y)
            {
                return x.GetDate().CompareTo(y.GetDate());
            }
        }
        

        public List<MusicItem> GetMusicItems()
        {
            var result = new List<MusicItem>();
            var tracks = System.IO.Directory.GetFiles(Server.MapPath("~/Music"));
            var thumbs = new List<string>()
            {
                "/Images/onstage_1.jpg",
                "/Images/10154494_681627485207291_8110023585070204411_n.jpg",
                "https://fbcdn-sphotos-b-a.akamaihd.net/hphotos-ak-xtp1/v/t1.0-9/11061775_827522667284438_4412268658479813289_n.jpg?oh=df05855dcc938558f92f793840c590b6&oe=55A7F389&__gda__=1433670847_36a90335807b2c4c1ea685a32a881418"
            };
            var rand = new Random();
            int cnt;
            cnt = 0;
            if (tracks.Length > 0)
            {
                foreach (var track in tracks)
                {
                    result.Add(new MusicItem()
                    {
                        Description = "This is information about the track!",
                        Title = System.IO.Path.GetFileNameWithoutExtension(track),
                        ThumbUri = thumbs[rand.Next(0, thumbs.Count)],
                        Type = "music",
                        Url = track

                    });
                    cnt++;
                }
               
            }
            return result;
        } 


        public List<NewsItem> GetNewsItems()
        {
            var result = new List<NewsItem>();
            
            return result;
        } 
        public interface ITileItemContainer
        {
             string Type { get; set; }
             DateTime Date { get; set; }
        }

        
        public class YouTubePlaylistItem : IItemContainer
        {
            public string Title { get; set; }
            public string Id { get; set; }
            public List<string> ThumbnailsList { get; set; }
            public string Description { get; set; }

            public ItemType Type { get; set; }
            public bool UseOnHomePage { get; set; }
            public DateTime GetDate()
            {
                return Date;
            }

            public string DateString
            {
                get { return Date.ToShortDateString(); }
            }

            public DateTime Date { get; set; }
        }
        public class MusicItem : ITileItemContainer
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string Description { get; set; }
            public string ThumbUri { get; set; }
            public string Type { get; set; }
            public DateTime Date { get; set; }
        }
        public class NewsItem : ITileItemContainer
        {
            public string Type { get; set; }
            public DateTime Date { get; set; }
            public string PhotoUri { get; set; }
            public string Headline { get; set; }
            public string Heading { get; set; }
            public string Paragraph { get; set; }
            public string FullStoryLink { get; set; }
        }
    }
}
