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
            toolbarView.FavouriteChanged += OnButtonFavouriteCheckStateChanged;

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

        private void OnButtonFavouriteCheckStateChanged(object sender, EventArgs e)
        {
            toolbarView.FavouriteImage = toolbarView.EpisodeIsFavourite            
                ? IconResources.star_icon_fill_32
                : IconResources.star_icon_32;
        }


        private void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            podcastPlayer.UnloadEpisode();
            if (subscriptionView.SelectedNode == null) return;

            var selectedEpisode = subscriptionView.SelectedNode.Tag as Episode;
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
            var selectedPodcast = subscriptionView.SelectedNode.Tag as Podcast;
            if (selectedPodcast != null)
            {
                mainFormView.ShowPodcastView();
                podcastView.SetPodcastTitle(selectedPodcast.Title);
                podcastView.SetEpisodeCount(String.Format("{0} episodes", selectedPodcast.Episodes.Count));
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
            var pod = subscriptionView.SelectedNode.Tag as Podcast;
            if (pod != null)
            {
                podcasts.Remove(pod);
                subscriptionView.RemoveNode(pod.Id.ToString());
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
            subscriptionView.SelectNode(podcasts.SelectMany(p => p.Episodes).First().Guid);
        }

        private void AddPodcastToTreeView(Podcast podcast)
        {
            var podNode = new TreeNode(podcast.Title) { Tag = podcast, Name = podcast.Id.ToString() };
            foreach (var episode in podcast.Episodes)
            {
                podNode.Nodes.Add(new TreeNode(episode.Title) { Tag = episode, Name = episode.Guid });
            }

            subscriptionView.AddNode(podNode);
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