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
    public partial class Form1 : Form
    {
        private Episode currentEpisode;
        private List<Podcast> podcasts;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            listBoxPodcasts.DisplayMember = "Title";

            foreach (var pod in podcasts)
            {
                UpdatePodcast(pod);
                listBoxPodcasts.Items.Add(pod);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxEpisodes.Items.Clear();
            if (listBoxPodcasts.SelectedIndex == -1) return;
            var pod = podcasts[listBoxPodcasts.SelectedIndex];
            foreach (var episode in pod.Episodes)
            {
                listBoxEpisodes.Items.Add(episode.Title);
            }
        }

        private void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            SaveEpisode();
            currentEpisode = podcasts[listBoxPodcasts.SelectedIndex].Episodes[listBoxEpisodes.SelectedIndex];
            textBoxEpisodeTitle.Text = currentEpisode.Title;
            textBoxPublicationDate.Text = currentEpisode.PubDate;
            textBoxDescription.Text = currentEpisode.Description;
            checkBoxIsFavourite.Checked = currentEpisode.IsFavourite;
            currentEpisode.IsNew = false;
            numericUpDownRating.Value = currentEpisode.Rating;
            textBoxTags.Text = String.Join(",", currentEpisode.Tags ?? new string[0]);
            textBoxNotes.Text = currentEpisode.Notes ?? "";
        }

        private void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = textBoxTags.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = (int)numericUpDownRating.Value;
            currentEpisode.IsFavourite = checkBoxIsFavourite.Checked;
            currentEpisode.Notes = textBoxNotes.Text;
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            Process.Start(currentEpisode.AudioFile ?? currentEpisode.Link);
        }

        private void OnButtonRemovePodcastClick(object sender, EventArgs e)
        {
            listBoxPodcasts.Items.Remove(listBoxPodcasts.SelectedItem);
            listBoxPodcasts.SelectedIndex = 0;
        }

        private void OnButtonAddSubscriptionClick(object sender, EventArgs e)
        {
            var form = new NewPodcastForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var pod = new Podcast() {SubscriptionUrl = form.PodcastUrl };
                UpdatePodcast(pod);
                podcasts.Add(pod);
                var index = listBoxPodcasts.Items.Add(pod.Title);
                listBoxPodcasts.SelectedIndex = index;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveEpisode();
            var serializer = new XmlSerializer(podcasts.GetType());
            using (var s = File.Create("subscriptions.xml"))
            {
                serializer.Serialize(s, podcasts);
            }
        }
    }
}
