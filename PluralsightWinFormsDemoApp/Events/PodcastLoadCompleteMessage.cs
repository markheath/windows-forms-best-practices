using PluralsightWinFormsDemoApp.Events;
using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.Presenters
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