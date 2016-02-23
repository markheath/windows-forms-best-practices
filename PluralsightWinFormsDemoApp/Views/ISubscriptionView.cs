using System;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public interface ISubscriptionView
    {
        TreeNode SelectedNode { get; }

        void AddNode(TreeNode treeNode);
        void RemoveNode(string key);
        void SelectNode(string key);

        event EventHandler SelectionChanged;
    }
}