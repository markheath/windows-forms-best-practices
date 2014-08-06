using System.Windows.Forms;
using PluralsightWinFormsDemoApp.Commands;
using PluralsightWinFormsDemoApp.Views;

namespace PluralsightWinFormsDemoApp
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly Control episodeView;
        private readonly Control podcastView;

        public MainForm(Control episodeView, Control subscriptionControl, Control podcastView, IToolbarCommand[] commands)
        {
            InitializeComponent();
            this.episodeView = episodeView;
            this.podcastView = podcastView;
            episodeView.Dock = DockStyle.Fill;
            podcastView.Dock = DockStyle.Fill;
            subscriptionControl.Dock = DockStyle.Fill;

            splitContainer1.Panel1.Controls.Add(subscriptionControl);
            // TODO: inject the toolbar view
            toolBarView.SetCommands(commands);
        }

        public void ShowEpisodeView()
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(episodeView);
        }

        public void ShowPodcastView()
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(podcastView);
        }
    }
}
