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
        public Form1()
        {
            InitializeComponent();
        }

        private List<Podcast> podcasts;

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
                var feeds = new[]
                {
                    "http://hwpod.libsyn.com/rss",
                    "http://feeds.feedburner.com/herdingcode",
                    "http://www.pwop.com/feed.aspx?show=dotnetrocks&amp;filetype=master",
                    "http://feeds.feedburner.com/JesseLibertyYapcast",
                    "http://feeds.feedburner.com/HanselminutesCompleteMP3"
                };
                podcasts = feeds.Select(f => new Podcast() {SubscriptionUrl = f}).ToList();
            }

            foreach (var pod in podcasts)
            {
                UpdatePodcast(pod);
                listBox1.Items.Add(pod.Title);
            }
            // Rss20FeedFormatter didn't work



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
            podcast.Episodes = new List<Episode>();
            foreach (XmlNode item in items)
            {
                var guid = item["guid"].InnerText;
                var episode = podcast.Episodes.FirstOrDefault(e => e.Guid == guid);
                if (episode == null)
                {
                    episode = new Episode() { Guid = guid };
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
            var episode = podcasts[listBox1.SelectedIndex].Episodes[listBox2.SelectedIndex];
            textBox1.Text = episode.Title;
            textBox2.Text = episode.PubDate;
            textBox3.Text = episode.Description;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var episode = podcasts[listBox1.SelectedIndex].Episodes[listBox2.SelectedIndex];
            Process.Start(episode.AudioFile ?? episode.Link);
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
            var serializer = new XmlSerializer(podcasts.GetType());
            using (var s = File.OpenWrite("subscriptions.xml"))
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
    }
}
