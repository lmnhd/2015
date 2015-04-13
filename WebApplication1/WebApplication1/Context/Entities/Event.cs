using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RicoGMB.Context.Entities
{
    public class Event : IItemContainer
    {
        public virtual int Id { get; set; }
        public virtual DateTime EventDate { get; set; }
        public virtual string Title { get; set; }
        public virtual string Location { get; set; }
        public virtual string Description { get; set; }
        public virtual string ExtraInfo { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string PhotoLink { get; set; }

        public virtual ItemType Type { get; set; }
        public virtual bool UseOnHomePage { get; set; }
        [NotMapped]
        public string DateString
        {
            get
            {
                return EventDate.ToShortDateString();

            }
        }
        public DateTime GetDate()
        {
            return EventDate;
        }

    }
}