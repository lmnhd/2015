using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RicoGMB.Context.Entities
{
    public class AlbumContainer 
    {
        public virtual string AlbumTitle { get; set; }
        [Key]
        public virtual int AlbumId { get; set; }

    }
    public class Track : IItemContainer
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime RecordingTime { get; set; }
        public virtual bool IsSingle { get; set; }
        
        public virtual AlbumContainer Album { get; set; }
        public virtual string Uri { get; set; }
        public virtual string Producer { get; set; }

        public  virtual ItemType Type { get; set; }
        public virtual bool UseOnHomePage { get; set; }
        [NotMapped]
        public string DateString
        {
            get
            {
                return RecordingTime.ToShortDateString();

            }
        }
        public DateTime GetDate()
        {
            return RecordingTime;
        }
    }
}