﻿using System;
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
    public partial class MainForm : Form, IMainFormView, IToolbarView
    {
        private Episode currentEpisode;
        private EpisodeView episodeView;
        private PodcastView podcastView;
        private SubscriptionView subscriptionView;
        private PodcastPlayer podcastPlayer; 
        private SubscriptionManager subscriptionManager;
        private PodcastLoader podcastLoader;
        private List<Podcast> podcasts;

        public MainForm()
        {            
            InitializeComponent();
            episodeView = new EpisodeView() {Dock = DockStyle.Fill};
            podcastView = new PodcastView() {Dock = DockStyle.Fill};
            subscriptionView = new SubscriptionView() {Dock = DockStyle.Fill};
            splitContainer1.Panel1.Controls.Add(subscriptionView);
            episodeView.Description = "";
            episodeView.Title = "";
            episodeView.PublicationDate = "";
            subscriptionView.SelectionChanged += OnSelectedEpisodeChanged;
            if (!SystemInformation.HighContrast)
            {
                BackColor = Color.White;
            }
            subscriptionManager = new SubscriptionManager("subscriptions.xml");
            podcastLoader = new PodcastLoader();
            podcastPlayer = new PodcastPlayer();
        }

        private async void OnFormLoad(object sender, EventArgs e)
        {
            podcasts = subscriptionManager.LoadPodcasts();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Space | Keys.Control))
            {
                buttonPlay.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SelectFirstEpisode()
        {
            subscriptionView.SelectEpisode(podcasts.SelectMany(p => p.Episodes).First());
        }

        private void AddPodcastToTreeView(Podcast pod)
        {
            subscriptionView.AddPodcast(pod);
        }

        private void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            podcastPlayer.UnloadEpisode();

            var selectedEpisode = subscriptionView.SelectedNodeTag as Episode;
            if (selectedEpisode != null)
            {
                ShowEpisodeView();
                SaveEpisode();
                currentEpisode = selectedEpisode;
                episodeView.Title = currentEpisode.Title;
                episodeView.PublicationDate = currentEpisode.PubDate;
                episodeView.Description = currentEpisode.Description;
                EpisodeIsFavourite = currentEpisode.IsFavourite;
                currentEpisode.IsNew = false;
                episodeView.Rating = currentEpisode.Rating;
                episodeView.Tags = String.Join(",", currentEpisode.Tags ?? new string[0]);
                episodeView.Notes = currentEpisode.Notes ?? "";
                podcastPlayer.LoadEpisode(currentEpisode);
            }
            var selectedPodcast = subscriptionView.SelectedNodeTag as Podcast;
            if (selectedPodcast != null)
            {
                ShowPodcastView();
                podcastView.SetPodcast(selectedPodcast);
            }
        }

        private void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = episodeView.Tags.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = episodeView.Rating;
            currentEpisode.IsFavourite = EpisodeIsFavourite;
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
                var pod = new Podcast() {SubscriptionUrl = form.PodcastUrl };
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

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveEpisode();
            subscriptionManager.Save(podcasts);
            podcastPlayer.Dispose();
        }

        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Help");
        }

        private void OnButtonPauseClick(object sender, EventArgs e)
        {
            podcastPlayer.Pause();
        }

        private void buttonFavourite_CheckStateChanged(object sender, EventArgs e)
        {
            EpisodeIsFavourite = buttonFavourite.Checked;
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            podcastPlayer.Stop();
        }

        public IEpisodeView EpisodeView { get; private set; }
        public IPodcastView PodcastView { get; private set; }
        public ISubscriptionView SubscriptionView { get; private set; }
        public IToolbarView ToolbarView { get; private set; }
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

        public event EventHandler AddPodcastClicked;
        public event EventHandler RemovePodcastClicked;

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

        bool EpisodeIsFavourite { get; set; }        
    }

    public interface IMainFormView
    {
        event EventHandler Load;
        event FormClosedEventHandler FormClosed;

        IEpisodeView EpisodeView { get; }
        IPodcastView PodcastView { get; }
        ISubscriptionView SubscriptionView { get; }
        IToolbarView ToolbarView { get; }

        void ShowEpisodeView();
        void ShowPodcastView();
    }

}
