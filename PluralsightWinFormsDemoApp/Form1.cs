using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Title";
            listBox2.DisplayMember = "Title";

            var feeds = new[]
            {
                "http://hwpod.libsyn.com/rss",
                "http://feeds.feedburner.com/herdingcode",
                "http://www.pwop.com/feed.aspx?show=dotnetrocks&amp;filetype=master",
                "http://feeds.feedburner.com/JesseLiberty-SilverlightGeek",
                "http://feeds.feedburner.com/HanselminutesCompleteMP3"
                //"http://www.dotnetrocks.com/feed.aspx",
            };
            foreach (var pod in feeds.Select(f => LoadPodcast(f)))
            {
                listBox1.Items.Add(pod);
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
                var xmlElement = item["description"];
                if (xmlElement != null) episode.Description = xmlElement.InnerText;
                episode.Link = item["link"].InnerText;
                podcast.Episodes.Add(episode);
                //this.items.Add(rssItem);
            }
            return podcast;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var pod = (Podcast)listBox1.SelectedItem;
            foreach (var episode in pod.Episodes)
            {
                listBox2.Items.Add(episode);
            }
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
    }
}
