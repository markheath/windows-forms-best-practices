using PluralsightWinFormsDemoApp.Model;

namespace PluralsightWinFormsDemoApp.Events
{
    class PeaksAvailableMessage : IApplicationEvent
    {
        public Episode Episode { get; private set; }

        public PeaksAvailableMessage(Episode episode)
        {
            Episode = episode;
        }
    }
}