using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.Events
{
    class PodcastLoadedMessage : IApplicationEvent
    {
        public Podcast Podcast { get; private set; }

        public PodcastLoadedMessage(Podcast podcast)
        {
            Podcast = podcast;
        }
    }
}