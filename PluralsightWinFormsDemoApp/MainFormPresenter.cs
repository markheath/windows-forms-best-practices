using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Properties;

namespace PluralsightWinFormsDemoApp
{
    class MainFormPresenter
    {
        private readonly IMainFormView mainFormView;
        private Episode currentEpisode;
        private readonly PodcastPlayer podcastPlayer;
        private readonly SubscriptionManager subscriptionManager;
        private readonly PodcastLoader podcastLoader;
        private readonly List<Podcast> podcasts;

        private readonly ISubscriptionView subscriptionView;
        private readonly IEpisodeView episodeView;
        private readonly IToolbarView toolbarView;
        private readonly IPodcastView podcastView;

        public MainFormPresenter(IMainFormView mainFormView)
        {
            subscriptionView = mainFormView.SubscriptionView;
            episodeView = mainFormView.EpisodeView;
            podcastView = mainFormView.PodcastView;
            toolbarView = mainFormView.ToolbarView;

            this.mainFormView = mainFormView;
            mainFormView.Load += MainFormViewOnLoad;
            mainFormView.FormClosed += MainFormViewOnFormClosed;
            mainFormView.HelpRequested += OnHelpRequested;
            mainFormView.KeyUp += MainFormViewOnKeyUp;

            toolbarView.PlayClicked += OnButtonPlayClick;
            toolbarView.StopClicked += OnButtonStopClick;
            toolbarView.PauseClicked += OnButtonPauseClick;
            toolbarView.RemovePodcastClicked += OnButtonRemovePodcastClick;
            toolbarView.AddPodcastClicked += OnButtonAddSubscriptionClick;
            toolbarView.FavouriteChanged += buttonFavourite_CheckStateChanged;

            episodeView.Description = "";
            episodeView.Title = "";
            episodeView.PublicationDate = "";
            subscriptionView.SelectionChanged += OnSelectedEpisodeChanged;
            subscriptionManager = new SubscriptionManager("subscriptions.xml");
            podcastLoader = new PodcastLoader();
            podcastPlayer = new PodcastPlayer();
            podcasts = subscriptionManager.LoadPodcasts();

            if (!SystemInformation.HighContrast)
            {
                mainFormView.BackColor = Color.White;
            }
        }

        private void MainFormViewOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == (Keys.Space | Keys.Control))
            {
                OnButtonPlayClick(this, EventArgs.Empty);
                keyEventArgs.Handled = true;
            }
        }

        private async void MainFormViewOnLoad(object sender, EventArgs eventArgs)
        {
            foreach (var pod in podcasts)
            {
                var podcast = pod;
                await podcastLoader.UpdatePodcast(podcast);
                AddPodcastToTreeView(pod);
            }

            SelectFirstEpisode();

            if (Settings.Default.FirstRun)
            {
                MessageBox.Show("Welcome! Get started by clicking Add to subscribe to a podcast");
                Settings.Default.FirstRun = false;
                Settings.Default.Save();
            }
        }

        private void OnHelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Help");
        }

        private void buttonFavourite_CheckStateChanged(object sender, EventArgs e)
        {
            toolbarView.EpisodeIsFavourite = toolbarView.EpisodeIsFavourite;
        }


        private void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            podcastPlayer.UnloadEpisode();

            var selectedEpisode = subscriptionView.SelectedNodeTag as Episode;
            if (selectedEpisode != null)
            {
                mainFormView.ShowEpisodeView();
                SaveEpisode();
                currentEpisode = selectedEpisode;
                episodeView.Title = currentEpisode.Title;
                episodeView.PublicationDate = currentEpisode.PubDate;
                episodeView.Description = currentEpisode.Description;
                toolbarView.EpisodeIsFavourite = currentEpisode.IsFavourite;
                currentEpisode.IsNew = false;
                episodeView.Rating = currentEpisode.Rating;
                episodeView.Tags = String.Join(",", currentEpisode.Tags ?? new string[0]);
                episodeView.Notes = currentEpisode.Notes ?? "";
                podcastPlayer.LoadEpisode(currentEpisode);
            }
            var selectedPodcast = subscriptionView.SelectedNodeTag as Podcast;
            if (selectedPodcast != null)
            {
                mainFormView.ShowPodcastView();
                podcastView.SetPodcast(selectedPodcast);
            }
        }

        private void MainFormViewOnFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            SaveEpisode();
            subscriptionManager.Save(podcasts);
            podcastPlayer.Dispose();
        }

        private void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = episodeView.Tags.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = episodeView.Rating;
            currentEpisode.IsFavourite = toolbarView.EpisodeIsFavourite;
            currentEpisode.Notes = episodeView.Notes;
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            podcastPlayer.Play();
        }

        private void OnButtonRemovePodcastClick(object sender, EventArgs e)
        {
            var pod = subscriptionView.SelectedNodeTag as Podcast;
            if (pod != null)
            {
                podcasts.Remove(pod);
                subscriptionView.RemovePodcast(pod);
                SelectFirstEpisode();
            }
        }

        private async void OnButtonAddSubscriptionClick(object sender, EventArgs e)
        {
            var form = new NewPodcastForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var pod = new Podcast() { SubscriptionUrl = form.PodcastUrl };
                try
                {
                    await podcastLoader.UpdatePodcast(pod);
                    podcasts.Add(pod);
                    AddPodcastToTreeView(pod);
                }
                catch (WebException)
                {
                    MessageBox.Show("Sorry, that podcast could not be found. Please check the URL");
                }
                catch (XmlException)
                {
                    MessageBox.Show("Sorry, that URL is not a podcast feed");
                }
            }
        }

        private void SelectFirstEpisode()
        {
            subscriptionView.SelectEpisode(podcasts.SelectMany(p => p.Episodes).First());
        }

        private void AddPodcastToTreeView(Podcast pod)
        {
            subscriptionView.AddPodcast(pod);
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            podcastPlayer.Stop();
        }

        private void OnButtonPauseClick(object sender, EventArgs e)
        {
            podcastPlayer.Pause();
        }
    }
}