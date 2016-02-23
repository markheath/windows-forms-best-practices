using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.Events
{
    class EpisodeSelectedMessage : IApplicationEvent
    {
        public EpisodeSelectedMessage(Episode episode)
        {
            Episode = episode;
        }

        public Episode Episode { get; private set; }
    }
}
