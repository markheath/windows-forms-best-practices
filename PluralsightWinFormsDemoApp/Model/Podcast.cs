using System;
using System.Collections.Generic;

namespace PluralsightWinFormsDemoApp.Model
{
    public class Podcast
    {
        public string SubscriptionUrl { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Episode> Episodes { get; set; }
        public Guid Id { get; set; }
    }
}