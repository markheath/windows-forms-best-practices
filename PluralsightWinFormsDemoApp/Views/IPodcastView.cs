namespace PluralsightWinFormsDemoApp.Views
{
    public interface IPodcastView
    {
        void SetPodcastTitle(string podcastTitle);
        void SetEpisodeCount(string episodeCount);
        void SetPodcastUrl(string url);
    }
}