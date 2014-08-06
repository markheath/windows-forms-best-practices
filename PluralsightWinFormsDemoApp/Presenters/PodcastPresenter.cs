using System;
using PluralsightWinFormsDemoApp.Events;

namespace PluralsightWinFormsDemoApp.Presenters
{
    class PodcastPresenter
    {
        private readonly IPodcastView podcastView;

        public PodcastPresenter(IPodcastView podcastView)
        {
            this.podcastView = podcastView;
            EventAggregator.Instance.Subscribe<PodcastSelectedMessage>(OnPodcastSelected);
        }

        private void OnPodcastSelected(PodcastSelectedMessage message)
        {
            podcastView.SetPodcastTitle(message.Podcast.Title);
            podcastView.SetEpisodeCount(String.Format("{0} episodes", message.Podcast.Episodes.Count));
            podcastView.SetPodcastUrl(message.Podcast.Link);
        }
    }
}