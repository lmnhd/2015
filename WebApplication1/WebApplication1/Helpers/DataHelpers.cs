using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RicoGMB.Context.Entities;
using RicoGMB.Controllers;

namespace RicoGMB.Helpers
{
    public  class IntsagramPost : IItemContainer
    {
        public  string Caption { get; set; }
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public string PhotoLink { get; set; }
        public ItemType Type { get; set; }
        public bool UseOnHomePage { get; set; }
        public DateTime GetDate()
        {
            return Date;
        }
    }

    public class InstagramGet
    {
        public object pagination { get; set; }
        public object meta { get; set; }
        public object data { get; set; }
    }

    public static class DataHelpers
    {
        
        public static IEnumerable<Track> GetLocalTracks()
        {
            var tracks = System.IO.Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~/Music"));
            var result = new List<Track>();
            if (tracks.Any())
            {
                result.AddRange(tracks.Select(track => new Track()
                {
                    Title = System.IO.Path.GetFileNameWithoutExtension(track), Uri = track,RecordingTime = DateTime.Now,
                    Type = ItemType.Track
                }));
            }
            return result;

        }

        public static IEnumerable<RicoGMB.Helpers.IntsagramPost> GetInstagramPosts()
        {
            var result = new List<IntsagramPost>();
            try
            {
                var request =
                    WebRequest.Create(
                        "https://api.instagram.com/v1/users/305708595/media/recent/?client_id=4b8fdefedd1e437aad91cd3c11c87523");

                WebResponse response = request.GetResponse();

                var dataStream = response.GetResponseStream();
                if (dataStream != null)
                {
                    var reader = new StreamReader(dataStream);
                    string data = reader.ReadToEnd();
                    dataStream.Close();

                    JObject obj = JObject.Parse(data);

                    if (obj != null)
                    {
                        var next = obj["pagination"]["next_url"].Value<string>();
                        JArray posts = JArray.FromObject(obj["data"]);
                        foreach (JToken post in posts)
                        {
                            var image = post["images"]["thumbnail"]["url"].Value<string>();
                            var caption = (string) post["caption"]["text"];
                            long time = post["created_time"].Value<long>();
                            DateTime startDate = new DateTime(1970, 1, 1);
                            DateTime finalDateTime = startDate.AddSeconds(time);

                            result.Add(new IntsagramPost()
                            {
                                Date = startDate,
                                Type = ItemType.Instagram,
                                Caption = caption,
                                DateString =
                                    startDate.Subtract(DateTime.Now).Hours.ToString(new NumberFormatInfo()) +
                                    "Hours Ago",
                                PhotoLink = image,
                                UseOnHomePage = true

                            });

                        }




                    }
                }
            }
            catch (Exception e)
            {
                
            }
            
            return result;
        }

        public static IEnumerable<HomeController.YouTubePlaylistItem> GetYouTubePlaylist()
        {

            var result = new List<HomeController.YouTubePlaylistItem>();
            var doc = new XmlDocument();
            try
            {
                doc.Load(
                    "http://gdata.youtube.com/feeds/api/playlists/PLfnmiU0mhKVRm-hdRVf02TAe3vbp2dDh3?max-results=25&start-index=1");
            }
            catch (Exception e)
            {
                return result;
            }



            var entrys = doc.GetElementsByTagName("entry");
            if (entrys.Count == 0)
            {
                return result;
            }
            foreach (XmlElement entry in entrys)
            {
                var item = new HomeController.YouTubePlaylistItem();
                item.Type = ItemType.Video;
                XmlNode xmlNode = entry.GetElementsByTagName("title").Item(0);
                if (xmlNode != null)
                {
                    item.Title = xmlNode.InnerText;
                }
                item.ThumbnailsList = new List<string>();
                var thumbs = entry.GetElementsByTagName("media:thumbnail");
                if (thumbs.Count > 0)
                {

                    foreach (XmlElement thumb in thumbs)
                    {
                        item.ThumbnailsList.Add(thumb.Attributes[0].Value);
                    }
                }
                var descNode = entry.GetElementsByTagName("yt:description").Item(0);
                if (descNode != null)
                {
                    item.Description = descNode.InnerText;
                }

                var idElement = entry.GetElementsByTagName("media:player").Item(0) as XmlElement;

                //XmlNode idNode = entry.GetElementsByTagName("media:player").Item(0);
                if (idElement != null)
                {
                    var temp = idElement.GetAttribute("url");
                    const string delimiterstring = @"=&";
                    var delimeters = delimiterstring.ToCharArray();
                    var splits = temp.Split(delimeters);

                    item.Id = splits[1];
                    item.UseOnHomePage = true;

                    item.Date = DateTime.Now.Subtract(TimeSpan.FromDays(90));


                    result.Add(item);
                }

            }


            return result;
        } 
    }
}