using System;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class SubscriptionView : UserControl, ISubscriptionView
    {
        public SubscriptionView()
        {
            InitializeComponent();
            treeViewPodcasts.AfterSelect += (s, a) => OnSelectionChanged();
        }

        public TreeNode SelectedNode
        {
            get
            {
                return treeViewPodcasts.SelectedNode;
            }
        }

        public void AddNode(TreeNode treeNode)
        {
            treeViewPodcasts.Nodes.Add(treeNode);
        }

        public void RemoveNode(string key)
        {
            var node = treeViewPodcasts.Nodes[key];
            treeViewPodcasts.Nodes.Remove(node);
        }

        public void SelectNode(string key)
        {            
            treeViewPodcasts.SelectedNode = treeViewPodcasts.Nodes[key];
        }

        public event EventHandler SelectionChanged;

        protected virtual void OnSelectionChanged()
        {
            var handler = SelectionChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
