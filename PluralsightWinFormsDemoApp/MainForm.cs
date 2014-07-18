using System;
using System.Drawing;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly EpisodeView episodeView;
        private readonly PodcastView podcastView;
        private readonly SubscriptionView subscriptionView;

        public MainForm()
        {
            InitializeComponent();
            episodeView = new EpisodeView() {Dock = DockStyle.Fill};
            podcastView = new PodcastView() {Dock = DockStyle.Fill};
            subscriptionView = new SubscriptionView() {Dock = DockStyle.Fill};
            splitContainer1.Panel1.Controls.Add(subscriptionView);
        }

        public IEpisodeView EpisodeView { get { return episodeView; } }
        public IPodcastView PodcastView { get { return podcastView; } }
        public ISubscriptionView SubscriptionView { get { return subscriptionView; } }
        public IToolbarView ToolbarView { get { return toolBarView; } }

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

    public interface IToolbarView
    {
        event EventHandler StopClicked;
        event EventHandler PlayClicked;
        event EventHandler PauseClicked;
        event EventHandler AddPodcastClicked;
        event EventHandler RemovePodcastClicked;
        event EventHandler FavouriteChanged;
        Image FavouriteImage { set; }

        bool EpisodeIsFavourite { get; set; }        
    }

    public interface IMainFormView
    {
        event EventHandler Load;
        event FormClosedEventHandler FormClosed;
        event HelpEventHandler HelpRequested;
        event KeyEventHandler KeyUp;

        IEpisodeView EpisodeView { get; }
        IPodcastView PodcastView { get; }
        ISubscriptionView SubscriptionView { get; }
        IToolbarView ToolbarView { get; }

        Color BackColor { get; set; }

        void ShowEpisodeView();
        void ShowPodcastView();
    }
}
