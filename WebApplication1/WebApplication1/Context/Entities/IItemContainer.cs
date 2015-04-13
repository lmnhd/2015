using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RicoGMB.Context.Entities
{
    public enum ItemType
    {
        Mixtape,
        Album,
        Track,
        News,
        Event,
        Video,
        Instagram
    }
    public interface IItemContainer
    {
        ItemType Type { get; set; }
        bool UseOnHomePage { get; set; }
        DateTime GetDate();
        string DateString { get;}
    }
}
