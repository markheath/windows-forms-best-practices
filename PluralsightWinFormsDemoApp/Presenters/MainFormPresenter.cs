using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Commands;
using PluralsightWinFormsDemoApp.Events;
using PluralsightWinFormsDemoApp.Views;

namespace PluralsightWinFormsDemoApp.Presenters
{
    class MainFormPresenter
    {
        private readonly IPodcastPlayer podcastPlayer;
        private readonly ISubscriptionManager subscriptionManager;
        private readonly IPodcastLoader podcastLoader;

        private readonly IMessageBoxDisplayService messageBoxDisplayService;
        private readonly ISettingsService settingsService;
        private readonly IToolbarCommand[] commands;

        public MainFormPresenter(IMainFormView mainFormView,
            IPodcastLoader podcastLoader,
            ISubscriptionManager subscriptionManager,
            IPodcastPlayer podcastPlayer,
            IMessageBoxDisplayService messageBoxDisplayService,
            ISettingsService settingsService,
            ISystemInformationService systemInformationService,
            IToolbarCommand[] commands)
        {

            mainFormView.Load += MainFormViewOnLoad;
            mainFormView.FormClosed += MainFormViewOnFormClosed;
            mainFormView.HelpRequested += OnHelpRequested;
            mainFormView.KeyUp += MainFormViewOnKeyUp;

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

            EventAggregator.Instance.Subscribe<EpisodeSelectedMessage>(m => mainFormView.ShowEpisodeView());
            EventAggregator.Instance.Subscribe<PodcastSelectedMessage>(m => mainFormView.ShowPodcastView());
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
                EventAggregator.Instance.Publish(new PodcastLoadedMessage(podcast));
            }

            EventAggregator.Instance.Publish(new PodcastLoadCompleteMessage(subscriptionManager.Subscriptions.ToArray()));

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


        private void MainFormViewOnFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            EventAggregator.Instance.Publish(new ApplicationClosingMessage());
            // TODO: wait for all views to publish 
            subscriptionManager.Save();
            podcastPlayer.Dispose();
        }

    }
}