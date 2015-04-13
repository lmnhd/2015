using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RicoGMB.Context.Entities
{
    public class News : IItemContainer
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Headline { get; set; }
        public virtual string FullStoryLink { get; set; }
        public virtual string Body { get; set; }
        public virtual string PhotoUri { get; set; }

        public virtual ItemType Type { get; set; }
        public virtual bool UseOnHomePage { get; set; }
        [NotMapped]
        public string DateString
        {
            get
            {
                return Date.ToShortDateString();

            }
        }
        public DateTime GetDate()
        {
            return Date;
        }
    }
}