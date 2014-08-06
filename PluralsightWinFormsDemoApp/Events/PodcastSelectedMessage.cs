using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.Events
{
    class PodcastSelectedMessage : IApplicationEvent
    {
        public PodcastSelectedMessage(Podcast podcast)
        {
            Podcast = podcast;
        }

        public Podcast Podcast { get; private set; }
    }
}