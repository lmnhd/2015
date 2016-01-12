using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using RicoGMB.Context.Entities;
using RicoGMB.Controllers;

namespace RicoGMB.Context
{
    public class RicoDBConfiguration : DropCreateDatabaseAlways<RicoContext>
    {
        protected override void Seed(RicoContext context)
        {


            context._Albums.AddRange(getAlbums());
            context._Events.AddRange(getEvents());
            context._Mixtapes.AddRange(getMixtapes());
            context._Newses.AddRange(getNewses());
            context._Tracks.AddRange(geTracks());
            context._Globals.Add(new ArtistGlobals
            {
                Address = "921 3rd Street Neptune Beach FL 32266",
                Booking = "904-568-2068",
                Email = "GMBENT223@gmail.com",
                ArtistName = "Rico Irvin",
                Facebook = "Rico GMB Irvin IG",
                Twitter = "RicoGMB@Twitter"
            });
            context.SaveChanges();

            base.Seed(context);
        }

        private IEnumerable<TrackSelector> GetAlbumTracks()
        {
            var result = new List<TrackSelector>();
            for (var i = 0; i < 12; i++)
            {
                result.Add(new TrackSelector()
                {
                    Index = i,
                    Title = string.Format("Song {0}",i)
                    
                });
            }
            return result;
        } 
        private IEnumerable<Album> getAlbums()
        {
            var result = new List<Album>();
            result.Add(new Album()
            {
                Title = "Fake album 1",
                UseOnHomePage = true,
                Description = "New album featuring Rock Lee and Herb",
                Type = ItemType.Album,
                PurchaseLink = "/",
                PhotoLink = "https://scontent.cdninstagram.com/hphotos-xaf1/t51.2885-15/e15/11123700_1577517955863735_507926478_n.jpg",
                ReleaseDate = DateTime.Now.AddDays(7),
                Tracks = GetAlbumTracks()
                
               

                
                
            });
            result.Add(new Album()
            {
                Title = "Fake album 2",
                UseOnHomePage = true,
                Description = "Get Fake album 2 now available on ITunes",
                Type = ItemType.Album,
                PurchaseLink = "/",
                PhotoLink = "https://scontent.cdninstagram.com/hphotos-xaf1/t51.2885-15/e15/11055745_1559166394357010_1334074889_n.jpg",
                ReleaseDate = DateTime.Now.AddDays(7),
                Tracks = GetAlbumTracks()




            });
            return result;
        }

        private IEnumerable<Event> getEvents()
        {
            var result = new List<Event>
            {
                new Event()
                {
                    Description = "CelebritySaturday diamondawards edition March 14th hosted by biggvradio . djcutty904 and I well be celebrating our birthday with live performances by ricogmb in Jacksonville, FL bottomzup_904 bottomzup_highlife regg904to662",
                   EventDate = new DateTime(2015,4,14,21,0,0),
                   Location = "3909 Blanding Blvd",
                   Title = "Celebrity Saturday diamond awards edition",
                  PhotoLink = "https://scontent.cdninstagram.com/hphotos-xaf1/t51.2885-15/e15/11015646_1557143487897220_2082517329_n.jpg",
                 Price = 0,
                 UseOnHomePage = true,
                 ExtraInfo = "Please contact 904-555-1212 for availabilty!",
                Type = ItemType.Event,
                FullLink = "http://google.com"
                
                   
                },
                new Event()
                {
                    Description = "StreetTalk Industry Monday's and Bigga Rankin Present Rico GMB Performing Live. Monday April 6th...",
                    EventDate = new DateTime(2015,4,6),
                    Location = "257 Trinity ave Atlanta, GA",
                    Title = "Rico GMB Performing Live",
                    Price = 0,
                    PhotoLink = "https://scontent.cdninstagram.com/hphotos-xpa1/t51.2885-15/e15/928855_554312118044472_294860323_n.jpg",
                    UseOnHomePage = true,
                    Type = ItemType.Event,
                    ExtraInfo = ""
                }
            };
            return result;
        } 
        private IEnumerable<Mixtape> getMixtapes()
        {
            var result = new List<Mixtape>();
            result.Add(new Mixtape()
            {
                Title = "Da-Cook Up",
                HostedBy = "DJ Shab & Bigga Rankin",
                Description = "12 Hot new tracks By RICO GMB",
                MultiArtist = false,
                DownloadUri = "http://indy.livemixtapes.com/mixtapes/31152/rico-da-cook-up.html",
                UseOnHomePage = true,
                PhotoLink = "http://images.livemixtapes.com/artists/biggarankin/rico-da_cook_up/cover.jpg",
               PlayerEmbed = WebUtility.HtmlEncode("<iframe width=\"400\" height=\"460\" src=\"http://www.livemixtapes.com/embed.php?album_id=31152\" border=\"0\" frameborder=\"0\" style=\"border: 0\" scrolling=\"no\" seamless=\"seamless\"></iframe>"),
               Type = ItemType.Mixtape,
               ReleaseDate = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
               Tracks = GetAlbumTracks()
                
            });
            result.Add(new Mixtape()
            {
                Title = "The Streets A & R",
                HostedBy = "Bigga Rankin",
                Description = "Bigga Rankin presents \"The Street's A & R\" featuring Rico GMB",
                MultiArtist = true,
                DownloadUri = "http://www.datpiff.com/BiggaRankin00-The-Streets-AR-mixtape.648542.html",
                UseOnHomePage = true,
                PhotoLink = "http://hw-img.datpiff.com/m4f186b7/BIGGA_RANKIN_The_Streets_Ar-front-large.jpg",
                PlayerEmbed = WebUtility.HtmlEncode("<iframe src=\"http://www.datpiff.com/embed/m4f186b7/\" width=\"300\" height=\"400\" frameborder=\"0\" btn></iframe>"),
                Type = ItemType.Mixtape,
                ReleaseDate = DateTime.Now.Subtract(TimeSpan.FromDays(30)),
                Tracks = GetAlbumTracks()

            });
            return result;
        } 
        private IEnumerable<Track> geTracks()
        {
            return Helpers.DataHelpers.GetLocalTracks();
        }

        private IEnumerable<News> getNewses()
        {
            var result = new List<News>()
            {
                new News()
                {
                    Type = ItemType.News,
                    Body =
                        @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce vel congue nisi. Suspendisse faucibus ante eu iaculis tristique. Proin vel porttitor risus, malesuada consequat odio. Curabitur porta, lorem fermentum dapibus ultrices, leo massa ",
                    UseOnHomePage = true,
                    Headline = "Rico GMB Nominated for 'Diamond Award' ",
                    FullStoryLink = "/",
                    PhotoUri =
                        "https://scontent.cdninstagram.com/hphotos-xaf1/t51.2885-15/e15/11137918_1625594717673926_1824793018_n.jpg",
                    Date = DateTime.Now
                },
                new News()
                {
                    Type = ItemType.News,
                    Body =
                        @"Curabitur vel commodo turpis. Donec consectetur quam sed ante efficitur pharetra. Maecenas porttitor lectus metus, vitae sagittis libero dignissim et. Sed a leo sapien. Nullam iaculis lacus id scelerisque pharetra. Nullam ornare ligula facilisis nisl ultrices porta.",
                    UseOnHomePage = true,
                    Headline = "Nullam iaculis lacus id scelerisque pharetra.",
                    FullStoryLink = "/",
                    PhotoUri =
                        "https://scontent.cdninstagram.com/hphotos-xfa1/t51.2885-15/e15/11117102_837917696257957_204626260_n.jpg",
                    Date = DateTime.Now
                }
            };
            return result;
        
        } 
    }

   
}