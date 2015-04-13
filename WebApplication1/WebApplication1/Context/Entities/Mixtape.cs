using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RicoGMB.Context.Entities
{
    public class Mixtape : IItemContainer
    {
        public virtual string Title { get; set; }
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string HostedBy { get; set; }
        public virtual string PhotoLink { get; set; }
        public virtual string DownloadUri { get; set; }
        public virtual bool MultiArtist { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual IEnumerable<TrackSelector> Tracks { get; set; }
        public virtual ItemType Type { get; set; }
        public virtual bool UseOnHomePage { get; set; }
        [NotMapped]
        public string DateString
        {
            get
            {
                return ReleaseDate.ToShortDateString();

            }
        }
        [NotMapped]
        public string DecodedEmbed { get; set; }
        public DateTime GetDate()
        {
            return ReleaseDate;
        }

        public virtual string PlayerEmbed { get; set; }
    }
}