using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.BusinessLogic;

namespace PluralsightWinFormsDemoApp
{
    class MainFormPresenter
    {
        private readonly IMainFormView mainFormView;
        private Episode currentEpisode;
        private readonly IPodcastPlayer podcastPlayer;
        private readonly ISubscriptionManager subscriptionManager;
        private readonly IPodcastLoader podcastLoader;

        private readonly ISubscriptionView subscriptionView;
        private readonly IEpisodeView episodeView;
        private readonly IToolbarView toolbarView;
        private readonly IPodcastView podcastView;
        private readonly IMessageBoxDisplayService messageBoxDisplayService;
        private readonly ISettingsService settingsService;
        private readonly IToolbarCommand[] commands;
        private readonly Timer timer;

        public MainFormPresenter(IMainFormView mainFormView,
            IPodcastLoader podcastLoader,
            ISubscriptionManager subscriptionManager,
            IPodcastPlayer podcastPlayer,
            IMessageBoxDisplayService messageBoxDisplayService,
            ISettingsService settingsService,
            ISystemInformationService systemInformationService,
            IToolbarCommand[] commands)
        {
            subscriptionView = mainFormView.SubscriptionView;
            episodeView = mainFormView.EpisodeView;
            podcastView = mainFormView.PodcastView;
            toolbarView = mainFormView.ToolbarView;
            toolbarView.SetCommands(commands);

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += TimerOnTick;
            timer.Start();

            this.mainFormView = mainFormView;
            mainFormView.Load += MainFormViewOnLoad;
            mainFormView.FormClosed += MainFormViewOnFormClosed;
            mainFormView.HelpRequested += OnHelpRequested;
            mainFormView.KeyUp += MainFormViewOnKeyUp;

            episodeView.Title = "";
            episodeView.PublicationDate = "";
            subscriptionView.SelectionChanged += OnSelectedEpisodeChanged;
            this.subscriptionManager = subscriptionManager;
            this.podcastLoader = podcastLoader;
            this.podcastPlayer = podcastPlayer;
            this.messageBoxDisplayService = messageBoxDisplayService;
            this.settingsService = settingsService;
            this.commands = commands;
            this.episodeView.NoteCreated += EpisodeViewOnNoteCreated;

            if (!systemInformationService.IsHighContrastColourScheme)
            {
                mainFormView.BackColor = Color.White;
            }

            episodeView.PositionChanged += (s, a) => podcastPlayer.PositionInSeconds = episodeView.PositionInSeconds;
        }

        private void EpisodeViewOnNoteCreated(object sender, NoteArgs noteArgs)
        {
            currentEpisode.Notes = String.Format(episodeView.Notes + "{0:hh\\:mm\\:ss}: {1}\r\n", 
                noteArgs.Position, noteArgs.Note);
            episodeView.Notes = currentEpisode.Notes;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            if (podcastPlayer != null && podcastPlayer.IsPlaying)
            {
                episodeView.PositionInSeconds = podcastPlayer.PositionInSeconds;
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

            var selectedEpisode = subscriptionView.SelectedNode.Tag as Episode;
            if (selectedEpisode != null)
            {
                EventAggregator.Instance.Publish(new EpisodeSelectedMessage(selectedEpisode));
                mainFormView.ShowEpisodeView();
                SaveEpisode();
                currentEpisode = selectedEpisode;
                episodeView.Title = currentEpisode.Title;
                episodeView.PublicationDate = currentEpisode.PubDate;
                episodeView.Description = currentEpisode.Description;
                //toolbarView.EpisodeIsFavourite = currentEpisode.IsFavourite; now handled by the IsFavouriteCommand
                currentEpisode.IsNew = false;
                episodeView.Rating = currentEpisode.Rating;
                episodeView.Tags = String.Join(",", currentEpisode.Tags ?? new string[0]);
                episodeView.Notes = currentEpisode.Notes ?? "";
                podcastPlayer.LoadEpisode(currentEpisode);
                if (currentEpisode.Peaks == null || currentEpisode.Peaks.Length == 0)
                {
                    episodeView.SetPeaks(null);
                    currentEpisode.Peaks = await podcastPlayer.LoadPeaksAsync();
                }
                episodeView.SetPeaks(currentEpisode.Peaks); 
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
            SaveEpisode();
            subscriptionManager.Save();
            podcastPlayer.Dispose();
        }

        private void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = episodeView.Tags.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = episodeView.Rating;
            //currentEpisode.IsFavourite = toolbarView.EpisodeIsFavourite; - now updated in realtime by the FavouriteCommand
            currentEpisode.Notes = episodeView.Notes;
        }
    }
}