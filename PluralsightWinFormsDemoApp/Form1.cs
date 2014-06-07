using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace PluralsightWinFormsDemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Podcast> podcasts = new List<Podcast>();

        private void Form1_Load(object sender, EventArgs e)
        {
            var feeds = new[]
            {
                "http://hwpod.libsyn.com/rss",
                "http://feeds.feedburner.com/herdingcode",
                "http://www.pwop.com/feed.aspx?show=dotnetrocks&amp;filetype=master",
                "http://feeds.feedburner.com/JesseLibertyYapcast",
                "http://feeds.feedburner.com/HanselminutesCompleteMP3"
                //"http://www.dotnetrocks.com/feed.aspx",
            };
            foreach (var pod in feeds.Select(f => LoadPodcast(f)))
            {
                podcasts.Add(pod);
                listBox1.Items.Add(pod.Title);
            }
            // Rss20FeedFormatter didn't work
        }

        Podcast LoadPodcast(string url)
        {
            var doc = new XmlDocument();
            doc.Load(url);

            XmlElement channel = doc["rss"]["channel"];
            XmlNodeList items = channel.GetElementsByTagName("item");
            var podcast = new Podcast();
            podcast.Title = channel["title"].InnerText;
            podcast.Link = channel["link"].InnerText;
            podcast.Description = channel["description"].InnerText;
            podcast.Episodes = new List<Episode>();
            foreach (XmlNode item in items)
            {

                var episode = new Episode();
                episode.Title = item["title"].InnerText;
                episode.PubDate = item["pubDate"].InnerText;
                var xmlElement = item["description"];
                if (xmlElement != null) episode.Description = xmlElement.InnerText;
                episode.Link = item["link"].InnerText;
                var enclosureElement = item["enclosure"];
                if (enclosureElement != null) episode.AudioFile = enclosureElement.Attributes["url"].InnerText;
                podcast.Episodes.Add(episode);
                //this.items.Add(rssItem);
            }
            return podcast;
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
    }

    class Podcast
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Episode> Episodes { get; set; }
    }

    class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
        public string AudioFile { get; set; }
    }
}
