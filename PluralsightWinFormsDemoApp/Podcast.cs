using System.Collections.Generic;

namespace PluralsightWinFormsDemoApp
{
    public class Podcast
    {
        public string SubscriptionUrl { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}