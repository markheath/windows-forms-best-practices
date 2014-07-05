using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class SubscriptionView : UserControl
    {
        public SubscriptionView()
        {
            InitializeComponent();
        }

        private void treeViewPodcasts_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var cm = new ContextMenu();
                cm.MenuItems.Add(new MenuItem("Unsubscribe"));
                cm.Show(this, e.Location);
            }
        }

        private void treeViewPodcasts_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
