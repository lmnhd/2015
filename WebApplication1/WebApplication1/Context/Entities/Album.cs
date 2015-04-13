using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RicoGMB.Context.Entities
{
    public class Album : IItemContainer
    {
        
        public virtual string Title { get; set; }
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string PhotoLink { get; set; }
        public virtual string PurchaseLink { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual IEnumerable<TrackSelector> Tracks { get; set; }


        public virtual ItemType Type { get; set; }
        public virtual bool UseOnHomePage { get; set; }
        public DateTime GetDate()
        {
            return ReleaseDate;
        }
        [NotMapped]
        public string DateString {
            get
            {
                return ReleaseDate.ToShortDateString();
                
            }
            }
    }
}