using System;
using System.Linq;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Events;
using PluralsightWinFormsDemoApp.Model;
using PluralsightWinFormsDemoApp.Views;

namespace PluralsightWinFormsDemoApp.Presenters
{
    class SubscriptionPresenter
    {
        private readonly ISubscriptionView subscriptionView;
        private readonly IPodcastPlayer podcastPlayer;

        public SubscriptionPresenter(ISubscriptionView subscriptionView, IPodcastPlayer podcastPlayer)
        {
            this.subscriptionView = subscriptionView;
            this.podcastPlayer = podcastPlayer;
            subscriptionView.SelectionChanged += OnSelectedEpisodeChanged;
            EventAggregator.Instance.Subscribe<PodcastLoadedMessage>(m => AddPodcastToTreeView(m.Podcast));
            EventAggregator.Instance.Subscribe<PodcastLoadCompleteMessage>(m => subscriptionView.SelectNode(m.Subscriptions.SelectMany(p => p.Episodes).First().Guid));
        }

        private void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            podcastPlayer.UnloadEpisode();
            if (subscriptionView.SelectedNode == null) return;

            var selectedEpisode = subscriptionView.SelectedNode.Tag as Episode;
            if (selectedEpisode != null)
            {
                EventAggregator.Instance.Publish(new EpisodeSelectedMessage(selectedEpisode));
            }
            var selectedPodcast = subscriptionView.SelectedNode.Tag as Podcast;
            if (selectedPodcast != null)
            {
                EventAggregator.Instance.Publish(new PodcastSelectedMessage(selectedPodcast));
            }
        }

        public void AddPodcastToTreeView(Podcast podcast)
        {
            var podNode = new TreeNode(podcast.Title) { Tag = podcast, Name = podcast.Id.ToString() };
            foreach (var episode in podcast.Episodes)
            {
                podNode.Nodes.Add(new TreeNode(episode.Title) { Tag = episode, Name = episode.Guid });
            }

            subscriptionView.AddNode(podNode);
        }
    }
}