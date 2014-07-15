using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using PluralsightWinFormsDemoApp.BusinessLogic;
using PluralsightWinFormsDemoApp.Properties;

namespace PluralsightWinFormsDemoApp
{
    public partial class MainForm : Form
    {
        private Episode currentEpisode;
        private EpisodeView episodeView;
        private PodcastView podcastView;
        private SubscriptionView subscriptionView;
        private PodcastPlayer podcastPlayer; 
        private SubscriptionManager subscriptionManager;
        private PodcastLoader podcastLoader;

        public MainForm()
        {            
            InitializeComponent();
            episodeView = new EpisodeView() {Dock = DockStyle.Fill};
            podcastView = new PodcastView() {Dock = DockStyle.Fill};
            subscriptionView = new SubscriptionView() {Dock = DockStyle.Fill};
            splitContainer1.Panel1.Controls.Add(subscriptionView);
            episodeView.labelDescription.Text = "";
            episodeView.labelEpisodeTitle.Text = "";
            episodeView.labelPublicationDate.Text = "";
            subscriptionView.treeViewPodcasts.AfterSelect += OnSelectedEpisodeChanged;
            if (!SystemInformation.HighContrast)
            {
                BackColor = Color.White;
            }
            subscriptionManager = new SubscriptionManager("subscriptions.xml");
            podcastLoader = new PodcastLoader();
            podcastPlayer = new PodcastPlayer();
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

        private async void OnFormLoad(object sender, EventArgs e)
        {

            var podcasts = subscriptionManager.LoadPodcasts();
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

        private void SelectFirstEpisode()
        {
            subscriptionView.treeViewPodcasts.SelectedNode =
                subscriptionView.treeViewPodcasts.Nodes[0].FirstNode;
        }

        private void AddPodcastToTreeView(Podcast pod)
        {
            var podNode = new TreeNode(pod.Title) { Tag = pod };
            subscriptionView.treeViewPodcasts.Nodes.Add(podNode);
            foreach (var episode in pod.Episodes)
            {
                podNode.Nodes.Add(new TreeNode(episode.Title) {Tag = episode});
            }
        }

        private void OnSelectedEpisodeChanged(object sender, TreeViewEventArgs e)
        {
            podcastPlayer.UnloadEpisode();

            var selectedEpisode = subscriptionView.treeViewPodcasts.SelectedNode.Tag as Episode;
            if (selectedEpisode != null)
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(episodeView);
                SaveEpisode();
                currentEpisode = selectedEpisode;
                episodeView.labelEpisodeTitle.Text = currentEpisode.Title;
                episodeView.labelPublicationDate.Text = currentEpisode.PubDate;
                episodeView.labelDescription.Text = currentEpisode.Description;
                buttonFavourite.Checked = currentEpisode.IsFavourite;
                currentEpisode.IsNew = false;
                episodeView.numericUpDownRating.Value = currentEpisode.Rating;
                episodeView.textBoxTags.Text = String.Join(",", currentEpisode.Tags ?? new string[0]);
                episodeView.textBoxNotes.Text = currentEpisode.Notes ?? "";
                podcastPlayer.LoadEpisode(currentEpisode);
            }
            var selectedPodcast = subscriptionView.treeViewPodcasts.SelectedNode.Tag as Podcast;
            if (selectedPodcast != null)
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(podcastView);
                podcastView.SetPodcast(selectedPodcast);
            }
        }

        private void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = episodeView.textBoxTags.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = (int)episodeView.numericUpDownRating.Value;
            currentEpisode.IsFavourite = buttonFavourite.Checked;
            currentEpisode.Notes = episodeView.textBoxNotes.Text;
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            podcastPlayer.Play();
        }

        private void OnButtonRemovePodcastClick(object sender, EventArgs e)
        {
            var nodeToRemove = subscriptionView.treeViewPodcasts.SelectedNode;
            if (nodeToRemove.Parent != null)
                nodeToRemove = nodeToRemove.Parent;
            subscriptionView.treeViewPodcasts.Nodes.Remove(nodeToRemove);
            SelectFirstEpisode();
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
            var podcasts = subscriptionView.treeViewPodcasts.Nodes
                    .Cast<TreeNode>()
                    .Select(tn => tn.Tag)
                    .OfType<Podcast>()
                    .ToList();
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
            buttonFavourite.Image = buttonFavourite.Checked
                ? IconResources.star_icon_fill_32
                : IconResources.star_icon_32;
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            podcastPlayer.Stop();
        }
    }
}
