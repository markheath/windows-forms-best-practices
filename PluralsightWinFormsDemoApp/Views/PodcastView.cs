using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class PodcastView : UserControl, IPodcastView
    {
        public PodcastView()
        {
            InitializeComponent();
            webBrowser1.DocumentCompleted += WebBrowser1OnDocumentCompleted;
        }

        private void WebBrowser1OnDocumentCompleted(object sender, 
            WebBrowserDocumentCompletedEventArgs webBrowserDocumentCompletedEventArgs)
        {
            foreach (var link in webBrowser1.Document.All.Cast<HtmlElement>().Where(e => e.TagName == "A"))
            {
                link.InnerText = "Pluralsight";
                link.SetAttribute("href", "http://pluralsight.com");
            }
        }

        public void SetPodcastTitle(string podcastTitle)
        {
            labelTitle.Text = podcastTitle;
        }

        public void SetEpisodeCount(string episodeCount)
        {
            labelEpisodeCount.Text = episodeCount;
        }

        public void SetPodcastUrl(string url)
        {
            webBrowser1.Navigate(url);
        }
    }

    public interface IPodcastView
    {
        void SetPodcastTitle(string podcastTitle);
        void SetEpisodeCount(string episodeCount);
        void SetPodcastUrl(string url);
    }
}
