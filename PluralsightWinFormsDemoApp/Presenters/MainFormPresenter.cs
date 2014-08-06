using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;

namespace PluralsightWinFormsDemoApp.Presenters
{
    class MainFormPresenter
    {
        private readonly IMainFormView mainFormView;
        private Episode currentEpisode;
        private readonly IPodcastPlayer podcastPlayer;
        private readonly ISubscriptionManager subscriptionManager;
        private readonly IPodcastLoader podcastLoader;

        private readonly ISubscriptionView subscriptionView;
        private readonly IToolbarView toolbarView;
        private readonly IPodcastView podcastView;
        private readonly IMessageBoxDisplayService messageBoxDisplayService;
        private readonly ISettingsService settingsService;
        private readonly IToolbarCommand[] commands;
        private readonly EpisodePresenter episodePresenter;

        public MainFormPresenter(IMainFormView mainFormView,
            EpisodePresenter episodePresenter,
            IPodcastLoader podcastLoader,
            ISubscriptionManager subscriptionManager,
            IPodcastPlayer podcastPlayer,
            IMessageBoxDisplayService messageBoxDisplayService,
            ISettingsService settingsService,
            ISystemInformationService systemInformationService,
            IToolbarCommand[] commands)
        {
            subscriptionView = mainFormView.SubscriptionView;
            this.episodePresenter = episodePresenter;
            podcastView = mainFormView.PodcastView;
            toolbarView = mainFormView.ToolbarView;
            toolbarView.SetCommands(commands);

            this.mainFormView = mainFormView;
            mainFormView.Load += MainFormViewOnLoad;
            mainFormView.FormClosed += MainFormViewOnFormClosed;
            mainFormView.HelpRequested += OnHelpRequested;
            mainFormView.KeyUp += MainFormViewOnKeyUp;

            subscriptionView.SelectionChanged += OnSelectedEpisodeChanged;
            this.subscriptionManager = subscriptionManager;
            this.podcastLoader = podcastLoader;
            this.podcastPlayer = podcastPlayer;
            this.messageBoxDisplayService = messageBoxDisplayService;
            this.settingsService = settingsService;
            this.commands = commands;


            if (!systemInformationService.IsHighContrastColourScheme)
            {
                mainFormView.BackColor = Color.White;
            }
        }

        private void MainFormViewOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            var command = commands.FirstOrDefault(c => c.ShortcutKey == keyEventArgs.KeyCode);
            if (command != null)
            {
                command.Execute();
                keyEventArgs.Handled = true;
            }
        }

        private async void MainFormViewOnLoad(object sender, EventArgs eventArgs)
        {
            foreach (var pod in subscriptionManager.Subscriptions)
            {
                var podcast = pod;
                await podcastLoader.UpdatePodcast(podcast);
                Utils.AddPodcastToTreeView(pod, subscriptionView);
            }

            Utils.SelectFirstEpisode(subscriptionView, subscriptionManager);

            if (settingsService.FirstRun)
            {
                messageBoxDisplayService.Show("Welcome! Get started by clicking Add to subscribe to a podcast");
                settingsService.FirstRun = false;
                settingsService.Save();
            }
        }

        private void OnHelpRequested(object sender, HelpEventArgs hlpevent)
        {
            messageBoxDisplayService.Show("Help");
        }

        private async void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            podcastPlayer.UnloadEpisode();
            if (subscriptionView.SelectedNode == null) return;
            
            episodePresenter.SaveEpisode();
            var selectedEpisode = subscriptionView.SelectedNode.Tag as Episode;
            if (selectedEpisode != null)
            {
                EventAggregator.Instance.Publish(new EpisodeSelectedMessage(selectedEpisode));
                mainFormView.ShowEpisodeView();
                currentEpisode = selectedEpisode;
                await episodePresenter.OnEpisodeSelected(currentEpisode);
            }
            var selectedPodcast = subscriptionView.SelectedNode.Tag as Podcast;
            if (selectedPodcast != null)
            {
                EventAggregator.Instance.Publish(new PodcastSelectedMessage(selectedPodcast));
                mainFormView.ShowPodcastView();
                podcastView.SetPodcastTitle(selectedPodcast.Title);
                podcastView.SetEpisodeCount(String.Format("{0} episodes", selectedPodcast.Episodes.Count));
                podcastView.SetPodcastUrl(selectedPodcast.Link);
            }
        }

        private void MainFormViewOnFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            episodePresenter.SaveEpisode();
            subscriptionManager.Save();
            podcastPlayer.Dispose();
        }

    }
}