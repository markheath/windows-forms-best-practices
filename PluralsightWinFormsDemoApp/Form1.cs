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

            foreach (var pod in podcasts)
            {
                UpdatePodcast(pod);
                listBox1.Items.Add(pod.Title);
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
            listBox2.Items.Clear();
            if (listBox1.SelectedIndex == -1) return;
            var pod = podcasts[listBox1.SelectedIndex];
            foreach (var episode in pod.Episodes)
            {
                listBox2.Items.Add(episode.Title);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveEpisode();
            currentEpisode = podcasts[listBox1.SelectedIndex].Episodes[listBox2.SelectedIndex];
            textBox1.Text = currentEpisode.Title;
            textBox2.Text = currentEpisode.PubDate;
            textBox3.Text = currentEpisode.Description;
            checkBox1.Checked = currentEpisode.IsFavourite;
            currentEpisode.IsNew = false;
            numericUpDown1.Value = currentEpisode.Rating;
            textBox4.Text = String.Join(",", currentEpisode.Tags ?? new string[0]);
            textBox6.Text = currentEpisode.Notes ?? "";
        }

        private void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = textBox4.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = (int)numericUpDown1.Value;
            currentEpisode.IsFavourite = checkBox1.Checked;
            currentEpisode.Notes = textBox6.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(currentEpisode.AudioFile ?? currentEpisode.Link);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new NewPodcastForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var pod = new Podcast() {SubscriptionUrl = form.PodcastUrl };
                UpdatePodcast(pod);
                podcasts.Add(pod);
                var index = listBox1.Items.Add(pod.Title);
                listBox1.SelectedIndex = index;
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

    public class Podcast
    {
        public string SubscriptionUrl { get; set;  }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Episode> Episodes { get; set; }
    }

    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
        public string AudioFile { get; set; }
        public string Guid { get; set; }
        public bool IsNew { get; set; }
        public bool IsFavourite { get; set; }
        public string[] Tags { get; set; }
        public string Notes { get; set; }
        public int Rating { get; set; }
    }

}
