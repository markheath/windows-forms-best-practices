using System;
using System.Linq;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class SubscriptionView : UserControl, ISubscriptionView
    {
        public SubscriptionView()
        {
            InitializeComponent();
            treeViewPodcasts.AfterSelect += (s, a) => OnSelectionChanged();
        }

        public object SelectedNodeTag
        {
            get
            {
                return treeViewPodcasts.SelectedNode == null ? 
                    null : treeViewPodcasts.SelectedNode.Tag;
            }
        }

        public void AddPodcast(Podcast podcast)
        {
            var podNode = new TreeNode(podcast.Title) { Tag = podcast };
            treeViewPodcasts.Nodes.Add(podNode);
            foreach (var episode in podcast.Episodes)
            {
                podNode.Nodes.Add(new TreeNode(episode.Title) { Tag = episode });
            }
        }

        public void RemovePodcast(Podcast podcast)
        {
            var node = treeViewPodcasts.Nodes.Cast<TreeNode>().FirstOrDefault(t => t.Tag == podcast);
            if (node != null)
                treeViewPodcasts.Nodes.Remove(node);
        }

        public void SelectEpisode(Episode episode)
        {
            var node = treeViewPodcasts.Nodes.Cast<TreeNode>()
                .SelectMany(tn => tn.Nodes.Cast<TreeNode>())
                .FirstOrDefault(t => t.Tag == episode);
            if (node != null)
                treeViewPodcasts.SelectedNode = node;
        }

        public event EventHandler SelectionChanged;

        protected virtual void OnSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }

    public interface ISubscriptionView
    {
        // either a Podcast or an Episode
        object SelectedNodeTag { get; }

        void AddPodcast(Podcast podcast);
        void RemovePodcast(Podcast podcast);

        void SelectEpisode(Episode episode);

        event EventHandler SelectionChanged;
    }
}
