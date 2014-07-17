using System;
using System.Drawing;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class MainForm : Form, IMainFormView, IToolbarView
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
        public IToolbarView ToolbarView { get { return this; } }

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

        public event EventHandler AddPodcastClicked
        {
            add {  buttonAddSubscription.Click += value; }
            remove {  buttonAddSubscription.Click -= value; }
        }

        public event EventHandler RemovePodcastClicked
        {
            add { buttonRemoveSubscription.Click += value; }
            remove { buttonRemoveSubscription.Click -= value; }
        }

        public event EventHandler StopClicked
        {
            add { buttonStop.Click += value; }
            remove { buttonStop.Click -= value; }
        }

        public event EventHandler PlayClicked
        {
            add { buttonPlay.Click += value; }
            remove { buttonPlay.Click -= value; }
        }

        public event EventHandler PauseClicked
        {
            add { buttonPause.Click += value; }
            remove { buttonPause.Click -= value; }
        }

        public event EventHandler FavouriteChanged
        {
            add { buttonFavourite.CheckStateChanged += value; }
            remove { buttonFavourite.CheckStateChanged -= value; }
        }

        public bool EpisodeIsFavourite
        {
            get { return buttonFavourite.Checked; }
            set
            {
                buttonFavourite.Checked = value;
                buttonFavourite.Image = value
                    ? IconResources.star_icon_fill_32
                    : IconResources.star_icon_32;
            }
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
