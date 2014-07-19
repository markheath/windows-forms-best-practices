using System.Linq;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    static class Utils
    {
        public static void AddPodcastToTreeView(Podcast podcast, ISubscriptionView subscriptionView)
        {
            var podNode = new TreeNode(podcast.Title) { Tag = podcast, Name = podcast.Id.ToString() };
            foreach (var episode in podcast.Episodes)
            {
                podNode.Nodes.Add(new TreeNode(episode.Title) { Tag = episode, Name = episode.Guid });
            }

            subscriptionView.AddNode(podNode);
        }

        public static void SelectFirstEpisode(ISubscriptionView subscriptionView, ISubscriptionManager subscriptionManager)
        {
            subscriptionView.SelectNode(subscriptionManager.Subscriptions.SelectMany(p => p.Episodes).First().Guid);
        }
    }
}