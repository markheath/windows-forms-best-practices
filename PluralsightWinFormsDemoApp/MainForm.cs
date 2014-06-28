using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PluralsightWinFormsDemoApp
{
    public partial class MainForm : Form
    {
        private Episode currentEpisode;

        public MainForm()
        {            
            InitializeComponent();
            episodeView.labelDescription.Text = "";
            episodeView.labelEpisodeTitle.Text = "";
            episodeView.labelPublicationDate.Text = "";
            subscriptionView.treeViewPodcasts.AfterSelect += OnSelectedEpisodeChanged;
            subscriptionView.buttonAddSubscription.Click += OnButtonAddSubscriptionClick;
            subscriptionView.buttonRemoveSubscription.Click += OnButtonRemovePodcastClick;
            episodeView.buttonPlay.Click += OnButtonPlayClick;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            List<Podcast> podcasts;
            if (File.Exists("subscriptions.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Podcast>));
                using (var s = File.OpenRead("subscriptions.xml"))
                {
                    podcasts = (List<Podcast>) serializer.Deserialize(s);
                }
            }
            else
            {
                var defaultFeeds = new[]
                {
                    "http://hwpod.libsyn.com/rss",
                    "http://feeds.feedburner.com/herdingcode",
                    "http://www.pwop.com/feed.aspx?show=dotnetrocks&amp;filetype=master",
                    "http://feeds.feedburner.com/JesseLibertyYapcast",
                    "http://feeds.feedburner.com/HanselminutesCompleteMP3"
                };
                podcasts = defaultFeeds.Select(f => new Podcast() { SubscriptionUrl = f }).ToList();
            }

            foreach (var pod in podcasts)
            {
                UpdatePodcast(pod);
                AddPodcastToTreeView(pod);
            }

            SelectFirstEpisode();
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

        void UpdatePodcast(Podcast podcast)
        {
            var doc = new XmlDocument();
            doc.Load(podcast.SubscriptionUrl);

            XmlElement channel = doc["rss"]["channel"];
            XmlNodeList items = channel.GetElementsByTagName("item");
            podcast.Title = channel["title"].InnerText;
            podcast.Link = channel["link"].InnerText;
            podcast.Description = channel["description"].InnerText;
            if (podcast.Episodes == null) podcast.Episodes = new List<Episode>();
            foreach (XmlNode item in items)
            {
                var guid = item["guid"].InnerText;
                var episode = podcast.Episodes.FirstOrDefault(e => e.Guid == guid);
                if (episode == null)
                {
                    episode = new Episode() { Guid = guid, IsNew = true};
                    episode.Title = item["title"].InnerText;
                    episode.PubDate = item["pubDate"].InnerText;
                    var xmlElement = item["description"];
                    if (xmlElement != null) episode.Description = xmlElement.InnerText;
                    var element = item["link"];
                    if (element != null) episode.Link = element.InnerText;
                    var enclosureElement = item["enclosure"];
                    if (enclosureElement != null) episode.AudioFile = enclosureElement.Attributes["url"].InnerText;
                    podcast.Episodes.Add(episode);
                }
            }
        }

        private void OnSelectedEpisodeChanged(object sender, TreeViewEventArgs e)
        {
            var selectedEpisode = subscriptionView.treeViewPodcasts.SelectedNode.Tag as Episode;
            if (selectedEpisode != null)
            {
                SaveEpisode();
                currentEpisode = selectedEpisode;
                episodeView.labelEpisodeTitle.Text = currentEpisode.Title;
                episodeView.labelPublicationDate.Text = currentEpisode.PubDate;
                episodeView.labelDescription.Text = currentEpisode.Description;
                episodeView.checkBoxIsFavourite.Checked = currentEpisode.IsFavourite;
                currentEpisode.IsNew = false;
                episodeView.numericUpDownRating.Value = currentEpisode.Rating;
                episodeView.textBoxTags.Text = String.Join(",", currentEpisode.Tags ?? new string[0]);
                episodeView.textBoxNotes.Text = currentEpisode.Notes ?? "";
            }
        }

        private void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = episodeView.textBoxTags.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = (int)episodeView.numericUpDownRating.Value;
            currentEpisode.IsFavourite = episodeView.checkBoxIsFavourite.Checked;
            currentEpisode.Notes = episodeView.textBoxNotes.Text;
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            Process.Start(currentEpisode.AudioFile ?? currentEpisode.Link);
        }

        private void OnButtonRemovePodcastClick(object sender, EventArgs e)
        {
            var nodeToRemove = subscriptionView.treeViewPodcasts.SelectedNode;
            if (nodeToRemove.Parent != null)
                nodeToRemove = nodeToRemove.Parent;
            subscriptionView.treeViewPodcasts.Nodes.Remove(nodeToRemove);
            SelectFirstEpisode();
        }

        private void OnButtonAddSubscriptionClick(object sender, EventArgs e)
        {
            var form = new NewPodcastForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var pod = new Podcast() {SubscriptionUrl = form.PodcastUrl };
                UpdatePodcast(pod);
                AddPodcastToTreeView(pod);
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveEpisode();
            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var s = File.Create("subscriptions.xml"))
            {
                var podcasts = subscriptionView.treeViewPodcasts.Nodes
                    .Cast<TreeNode>()
                    .Select(tn => tn.Tag)
                    .OfType<Podcast>()
                    .ToList();
                serializer.Serialize(s, podcasts);
            }
        }
    }
}
