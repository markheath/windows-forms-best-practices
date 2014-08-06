using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.Events
{
    class PodcastLoadCompleteMessage : IApplicationEvent
    {
        private readonly Podcast[] subscriptions;

        public PodcastLoadCompleteMessage(Podcast[] subscriptions)
        {
            this.subscriptions = subscriptions;
        }

        public Podcast[] Subscriptions
        {
            get { return subscriptions; }
        }
    }
}