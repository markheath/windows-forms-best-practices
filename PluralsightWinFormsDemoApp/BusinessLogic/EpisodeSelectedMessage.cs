using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightWinFormsDemoApp.BusinessLogic
{
    class EpisodeSelectedMessage : IApplicationEvent
    {
        public EpisodeSelectedMessage(Episode episode)
        {
            Episode = episode;
        }

        public Episode Episode { get; private set; }
    }

    class PodcastSelectedMessage : IApplicationEvent
    {
        public PodcastSelectedMessage(Podcast podcast)
        {
            Podcast = podcast;
        }

        public Podcast Podcast { get; private set; }
    }
}
